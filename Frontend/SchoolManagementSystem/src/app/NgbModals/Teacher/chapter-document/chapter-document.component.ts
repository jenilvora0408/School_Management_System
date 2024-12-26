import { Component, Injector } from '@angular/core';
import { IGetChapterDocument } from '../../../models/teacher/get-chapter-document';
import { TeacherService } from '../../../services/teacher.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { IManageChapterDocumentInterface } from '../../../models/teacher/manage-chapter-document';
import { LoaderService } from '../../../shared/services/loader.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { IAddChapterDocumentInterface } from '../../../models/teacher/add-chapter-document';

@Component({
  selector: 'app-chapter-document',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './chapter-document.component.html',
  styleUrl: './chapter-document.component.scss',
})
export class ChapterDocumentComponent {
  courseId: number = 0;
  getChapterDocumentData: IGetChapterDocument = {
    documentId: 0,
    documentContent: '',
    courseId: 0,
    useDocumentFor: '',
  };
  canUploadDoc: boolean = false;
  documentError: string = '';
  uploadedFiles: { name: string; size: number; file: File }[] = [];
  isDragging: boolean = false;
  showDocumentErrors: boolean = false;
  maxFiles: number = 1;
  uploadedFile: string = '';
  responseString: string = '';
  chapterName: string = '';
  showDeleteConfirmation: boolean = false;
  userRole: number = 0;

  constructor(
    private teacherService: TeacherService,
    private modalService: NgbModal,
    private injector: Injector,
    private notificationService: NotificationService,
    private loaderService: LoaderService,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.courseId = this.injector.get('courseId');
    this.chapterName = this.injector.get('chapterName');
    this.userRole = this.authService.getUserType();
    this.getChapterDocument();
  }

  getChapterDocument(): void {
    this.teacherService.getChapterDocument(this.courseId).subscribe({
      next: (response: IResponse<IGetChapterDocument>) => {
        this.getChapterDocumentData = response.data;
        if (this.getChapterDocumentData.documentId == 0) {
          this.canUploadDoc = true;
        } else {
          this.canUploadDoc = false;
        }
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      },
    });
  }

  handleFileChange(event: any) {
    const files = event.target.files;

    if (files && files.length > 0) {
      const totalFiles = this.uploadedFiles.length + files.length;

      if (totalFiles > 7) {
        this.showDocumentErrors = true;
        this.documentError = ValidationMessageConstant.canUploadMax7Files;
        return;
      }

      Array.from(files).forEach((file: any) => {
        this.validateAndUpload(file);
      });
    }

    event.target.value = '';
  }

  onDragOver(event: DragEvent) {
    event.preventDefault();
    this.isDragging = true;
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    this.isDragging = false;

    const files = event.dataTransfer?.files;

    if (files && files.length > 0) {
      const totalFiles = this.uploadedFiles.length + files.length;

      if (totalFiles > 7) {
        this.showDocumentErrors = true;
        this.documentError = ValidationMessageConstant.canUploadMax7Files;
        return;
      }

      Array.from(files).forEach((file: File) => {
        this.validateAndUpload(file);
      });
    }
  }

  onDragLeave(event: DragEvent) {
    this.isDragging = false;
  }

  validateAndUpload(file: File) {
    const validExtensions = [
      'application/pdf',
      'application/msword',
      'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', // .xlsx
      'image/jpeg',
      'image/png',
      'image/jpg',
      'video/mp4',
    ];
    const maxSizeInMB = 5;
    const maxSizeInBytes = maxSizeInMB * 1024 * 1024;

    if (
      this.uploadedFiles.some(
        (uploadedFile) =>
          uploadedFile.name === file.name && uploadedFile.size === file.size
      )
    ) {
      this.showDocumentErrors = true;
      this.documentError = ValidationMessageConstant.cannotUploadSameFileTwice;
      return;
    }

    if (this.uploadedFiles.length >= 7) {
      this.showDocumentErrors = true;
      this.documentError = ValidationMessageConstant.canUploadMax7Files;
      return;
    }

    if (!validExtensions.includes(file.type)) {
      this.showDocumentErrors = true;
      this.documentError =
        ValidationMessageConstant.chapterDocumentExtensionError;
    } else if (file.size > maxSizeInBytes) {
      this.showDocumentErrors = true;
      this.documentError = ValidationMessageConstant.avatarImageSizeError;
    } else {
      this.showDocumentErrors = false;
      this.documentError = '';
      const reader = new FileReader();
      reader.onload = () => {
        const result = reader.result as string;

        if (
          result &&
          result.startsWith('data:') &&
          result.includes(';base64,')
        ) {
          this.uploadedFiles.push({
            name: file.name,
            size: file.size,
            file,
          });
        } else {
          console.error(ValidationMessageConstant.invalidBase64Url);
          this.showDocumentErrors = true;
          this.documentError = ValidationMessageConstant.cannotProcessFile;
        }
      };

      reader.onerror = (error) => {
        console.error('Error reading file:', error);
        this.showDocumentErrors = true;
        this.documentError = 'Error reading file.';
      };
      reader.readAsDataURL(file);
    }
  }

  removeFile(index: number) {
    this.uploadedFiles.splice(index, 1);
    if (
      this.documentError === ValidationMessageConstant.canUpload1FileOnly &&
      this.uploadedFiles.length < this.maxFiles
    ) {
      this.showDocumentErrors = false;
      this.documentError = '';
    }
  }

  close() {
    this.modalService.dismissAll();
  }

  onSubmit(): void {
    if (this.userRole === 3) {
      this.notificationService.error(
        ValidationMessageConstant.accessUnauthorized
      );
      return;
    }

    if (this.uploadedFiles.length === 0) {
      this.showDocumentErrors = true;
      this.documentError = ValidationMessageConstant.mustUploadDocument;
      return;
    }

    this.showDocumentErrors = false;
    this.documentError = '';
    this.loaderService.show();

    this.submitDocument();
  }

  submitDocument(): void {
    const documentDTOs = this.uploadedFiles.map((file) => {
      const fileNameParts = file.name.split('.');
      const documentExtension = fileNameParts.pop();
      const documentName = fileNameParts.join('.');

      return {
        documentContent: '',
        documentName: documentName,
        documentType: '',
        documentExtension: documentExtension || null,
      };
    });

    Promise.all(
      this.uploadedFiles.map(
        (file, index) =>
          new Promise<void>((resolve, reject) => {
            const reader = new FileReader();
            reader.onload = () => {
              const result = reader.result as string;
              documentDTOs[index].documentContent = result;
              resolve();
            };
            reader.onerror = (error) => {
              console.error('Error reading file:', error);
              reject(error);
            };
            reader.readAsDataURL(file.file);
          })
      )
    )
      .then(() => {
        const payload: IAddChapterDocumentInterface = {
          courseId: this.courseId,
          documentDTOs: documentDTOs,
        };

        console.log('Upload: ', payload);

        this.teacherService.addChapterDocuments(payload).subscribe({
          next: (response: IResponse<string>) => {
            this.responseString = response.data;
            this.loaderService.hide();
            this.notificationService.success(this.responseString);
            this.modalService.dismissAll();
          },
          error: (error: HttpErrorResponse) => {
            this.loaderService.hide();
            console.error(error);
          },
        });
      })
      .catch((error) => {
        this.loaderService.hide();
        console.error('Failed to process files:', error);
      });
  }

  deleteDocument(): void {
    if (this.userRole == 3) {
      this.notificationService.error(
        ValidationMessageConstant.accessUnauthorized
      );
      return;
    }
    this.showDeleteConfirmation = true;
  }

  confirmDelete(): void {
    this.uploadedFile = '';
    this.submitDocument();
  }
}
