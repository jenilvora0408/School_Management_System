import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { IContactPrincipalListInterface } from '../../../models/principal/contact-principal-list';
import { PrincipalService } from '../../../services/principal.service';
import { IResponse } from '../../../shared/models/IResponse';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { EditorConfig } from '@ckeditor/ckeditor5-core';
import {
  ClassicEditor,
  Autoformat,
  Bold,
  Italic,
  Underline,
  BlockQuote,
  Base64UploadAdapter,
  CloudServices,
  Essentials,
  Heading,
  Image,
  ImageCaption,
  ImageResize,
  ImageStyle,
  ImageToolbar,
  ImageUpload,
  PictureEditing,
  Indent,
  IndentBlock,
  Link,
  List,
  MediaEmbed,
  Mention,
  Paragraph,
  PasteFromOffice,
  Table,
  TableColumnResize,
  TableToolbar,
  TextTransformation,
} from 'ckeditor5';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { FormsModule } from '@angular/forms';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { IContactPrincipalResponse } from '../../../models/principal/contact-principal-response';
import { LoaderService } from '../../../shared/services/loader.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { Router } from '@angular/router';
import { CommonService } from '../../../shared/services/common.service';

@Component({
  selector: 'app-view-contact-request',
  standalone: true,
  imports: [HeaderComponent, CKEditorModule, ButtonComponent, FormsModule],
  templateUrl: './view-contact-request.component.html',
  styleUrl: './view-contact-request.component.scss',
})
export class ViewContactRequestComponent {
  importData!: IContactPrincipalListInterface;
  contactRequestId: number = 0;
  requestDocuments: string[] = [];
  username: string = '';
  subject: string = '';
  requestType: string = '';
  description: string = '';
  ckEditorContent: string = '';
  ckEditorValidationMessage: string = '';
  responseMessage: string = '';

  constructor(
    private principalService: PrincipalService,
    private loaderService: LoaderService,
    private notificationService: NotificationService,
    private router: Router,
    private commonService: CommonService
  ) {}

  ngOnInit(): void {
    const importDataArray = history.state
      .exportData as IContactPrincipalListInterface[];
    this.importData = importDataArray[0];

    this.contactRequestId = this.importData.contactPrincipalId;
    this.username = this.importData.userName;
    this.subject = this.importData.subject;
    this.requestType = this.importData.contactTypeTitle;
    this.description = this.importData.description;
    this.responseMessage = this.importData.responseMessage;
    console.log(this.importData, this.responseMessage);

    this.getContactRequestDocuments(this.contactRequestId);
  }

  public Editor = ClassicEditor;
  public config: EditorConfig = {
    plugins: [
      Autoformat,
      BlockQuote,
      Bold,
      CloudServices,
      Essentials,
      Heading,
      Image,
      ImageCaption,
      ImageResize,
      ImageStyle,
      ImageToolbar,
      ImageUpload,
      Base64UploadAdapter,
      Indent,
      IndentBlock,
      Italic,
      Link,
      List,
      MediaEmbed,
      Mention,
      Paragraph,
      PasteFromOffice,
      PictureEditing,
      Table,
      TableColumnResize,
      TableToolbar,
      TextTransformation,
      Underline,
    ],
    toolbar: [
      'undo',
      'redo',
      '|',
      'heading',
      '|',
      'bold',
      'italic',
      'underline',
      '|',
      'link',
      'uploadImage',
      'insertTable',
      'blockQuote',
      'mediaEmbed',
      '|',
      'bulletedList',
      'numberedList',
      '|',
      'outdent',
      'indent',
    ],
    heading: {
      options: [
        {
          model: 'paragraph',
          title: 'Paragraph',
          class: 'ck-heading_paragraph',
        },
        {
          model: 'heading1',
          view: 'h1',
          title: 'Heading 1',
          class: 'ck-heading_heading1',
        },
        {
          model: 'heading2',
          view: 'h2',
          title: 'Heading 2',
          class: 'ck-heading_heading2',
        },
        {
          model: 'heading3',
          view: 'h3',
          title: 'Heading 3',
          class: 'ck-heading_heading3',
        },
        {
          model: 'heading4',
          view: 'h4',
          title: 'Heading 4',
          class: 'ck-heading_heading4',
        },
      ],
    },
    image: {
      resizeOptions: [
        {
          name: 'resizeImage:original',
          label: 'Default image width',
          value: null,
        },
        { name: 'resizeImage:50', label: '50% page width', value: '50' },
        { name: 'resizeImage:75', label: '75% page width', value: '75' },
      ],
      toolbar: [
        'imageTextAlternative',
        'toggleImageCaption',
        '|',
        'imageStyle:inline',
        'imageStyle:wrapText',
        'imageStyle:breakText',
        '|',
        'resizeImage',
      ],
    },
    link: {
      addTargetToExternalLinks: true,
      defaultProtocol: 'https://',
    },
    table: {
      contentToolbar: ['tableColumn', 'tableRow', 'mergeTableCells'],
    },
  };

  getContactRequestDocuments(id: number): void {
    this.principalService
      .getContactPrincipalDocuments(id)
      .subscribe((response: IResponse<string[]>) => {
        this.requestDocuments = response.data;
        console.log(this.requestDocuments);
      });
  }

  downloadImage(imageUrl: string, index: number) {
    this.commonService.downloadImage(imageUrl, index);
  }

  onSubmit(): void {
    console.log('CKEditor content:', this.ckEditorContent);
    const contentLength = this.ckEditorContent.trim().length;
    console.log(contentLength);
    if(contentLength <= 0){
      this.ckEditorValidationMessage = ValidationMessageConstant.responseMessageRequired;
    }
    else if (contentLength < 15) {
      this.ckEditorValidationMessage = ValidationMessageConstant.shortResponse;
    } else if (contentLength > 2000) {
      this.ckEditorValidationMessage =
        ValidationMessageConstant.responseCannotExceed2000;
    } else {
      this.ckEditorValidationMessage = '';

      this.loaderService.show();

      const payload: IContactPrincipalResponse = {
        contactPrincipalId: this.contactRequestId,
        responseMessage: this.ckEditorContent,
      };

      this.principalService.postContactPrincipalResponse(payload).subscribe({
        next: (response: IResponse<null>) => {
          if (response.success) {
            this.loaderService.hide();
            this.router.navigate(['/principal/contact-requests'])
            this.notificationService.success(response.message);
          }
        },
        error: (error) => {
          this.loaderService.hide();
          this.notificationService.error(error.error.errors);
        },
      });
    }
  }

  onCancel(): void {}
}
