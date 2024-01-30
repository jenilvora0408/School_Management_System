export class  RoutingPathConstant {
  //authentication routing path
  public static login = 'login';
  public static loginUrl = '/login';

  public static verifyOtp = 'verify-otp';
  public static verifyOtpUrl = '/verify-otp';

  public static forgotPassword = 'forgot-password';
  public static forgotPasswordUrl = '/forgot-password';

  public static resetPassword = 'reset-password';
  public static resetPasswordUrl = '/reset-password';

  //manage authentication routing path
  public static unauthorize = 'unauthorize';
  public static unauthorizeUrl = '/unauthorize';

  public static sessionExpire = 'session-expired';
  public static sessionExpireUrl = '/session-expired';

  public static notFound = 'not-found';
  public static notFoundUrl = '/not-found';

  //after signin dashboard routing path
  public static principal = 'principal';
  public static teacher = 'teacher';
  public static student = 'student';

  public static dashboard = 'dashboard';
  public static dashboardUrl = '/dashboard';

  public static principalDashboard = 'principal/dashboard';
  public static principalDashboardUrl = '/principal/dashboard';

  public static teacherDashboard = 'teacher/dashboard';
  public static teacherDashboardUrl = '/teacher/dashboard';

  public static studentDashboard = 'student/dashboard';
  public static studentDashboardUrl = '/student/dashboard';

  //patient interface
  public static clinicalPathName = 'clinical-path';
  public static clinicalPath = 'patient/clinical-path';
  public static clinicalPathUrl = '/patient/clinical-path';

  public static patientFaqName = 'faq';
  public static patientFaq = 'patient/faq';
  public static patientFaqUrl = '/patient/faq';

  public static contactDoctorName = 'contact-doctor';
  public static contactDoctor = 'patient/contact-doctor';
  public static contactDoctorUrl = '/patient/contact-doctor';

  public static profileName = 'profile';
  public static profile = 'patient/profile';
  public static profileUrl = '/patient/profile';

  public static testExplainationName = 'test-explanation';
  public static testExplaination = 'patient/test-explanation';
  public static testExplainationUrl = '/patient/test-explanation';

  public static clinicalPathUpdateName = 'clinical-path-update';
  public static clinicalPathUpdate = 'patient/clinical-path-update';
  public static clinicalPathUpdateUrl = '/patient/clinical-path-update';

  //doctor interface
  public static patientListName = 'patients';
  public static patientList = 'doctor/patients';
  public static patientListUrl = '/doctor/patients';

  public static patientRegisterName = 'patients/register';
  public static patientRegister = 'doctor/patients/register';
  public static patientRegisterUrl = '/doctor/patients/register';

  public static getPatientName = 'patients/:id';
  public static getPatient = 'doctor/patients/:id';
  public static getPatientUrl = '/doctor/patients/:id';

  public static labName = 'lab';
  public static lab = 'doctor/lab';
  public static labUrl = '/doctor/lab';

  public static labRegisterName = 'lab/register';
  public static labRegister = 'doctor/lab/register';
  public static labRegisterUrl = '/doctor/lab/register';

  public static getLabName = 'lab/:id';
  public static getLab = 'doctor/lab/:id';
  public static getLabUrl = '/doctor/lab/:id';

  public static contactUsName = 'contact-us';
  public static contactUs = 'doctor/contact-us';
  public static contactUsUrl = '/doctor/contact-us';

  public static patientDetailsName = 'patient-detail';
  public static patientDetails = 'doctor/patient-detail';
  public static patientDetailsUrl = '/doctor/patient-detail';

  public static shipSampleName = 'ship-sample';
  public static shipSample = 'doctor/ship-sample';
  public static shipSampleUrl = '/doctor/ship-sample';

  public static reqMoreDoctName = 'request-more-info';
  public static reqMoreDoct = 'doctor/request-more-info';
  public static reqMoreDoctUrl = '/doctor/request-more-info';

  public static sentResultName = 'send-result';
  public static sentResult = 'doctor/send-result';
  public static sentResultUrl = '/doctor/send-result';

  public static readonly patients = 'patients';
  public static readonly labUser = 'lab';

  public static readonly idParam = ':id';

  public static readonly registerPatient = `${this.patients}/register`;
  public static readonly registerLabUrl = `${this.labUser}/register`;

  public static readonly getPatientUser = `${this.patients}/${this.idParam}`;
  public static readonly getLabUser = `${this.labUser}/${this.idParam}`;

  public static readonly requestMoreInfoByDoctor = `request-more-info`;
  public static readonly labUserUrl = 'lab';

  public static seeClinicalPathName = 'see-clinical-path';
  public static seeClinicalPath = 'doctor/see-clinical-path';
  public static seeClinicalPathUrl = '/doctor/see-clinical-path';

  public static seeRequestedInfoName = 'see-requested-info';
  public static seeRequestedInfo = 'doctor/see-requested-info';
  public static seeRequestedInfoUrl = '/doctor/see-requested-info';

  public static addClinicalQuestionsName = 'add-clinical-questions';
  public static addClinicalQuestions = 'doctor/add-clinical-questions';
  public static addClinicalQuestionsUrl = '/doctor/add-clinical-questions';

  //lab interface
  public static labUploadResultName = 'upload-result';
  public static labUploadResult = 'lab/upload-result';
  public static labUploadResultUrl = '/lab/upload-result';

  public static labUpdateResultName = 'update-result';
  public static labUpdateResult = 'lab/update-result';
  public static labUpdateResultUrl = '/lab/update-result';

  //routing for header
  public static doctorHead = '/doctor';
  public static patientHead = '/patient';
  public static labHead = '/lab';
  public static dashboardHead = '/dashboard';
  public static patientsHead = '/patients';
  public static faqHead = '/faq';
  public static contactUsHead = '/contact-us';
  public static contactDoctorHead = '/contact-doctor';

  //routing for quicklinks
  public static qlPatientRegister = '/doctor/patients/register';
  public static qlContactUs = '/doctor/contact-us';
  public static qlTestExplaination = '/doctor/test-explanation';
  public static qlLabTestExplaination = '/lab/test-explanation';
  public static qlLabFaq = '/lab/faq';
}
