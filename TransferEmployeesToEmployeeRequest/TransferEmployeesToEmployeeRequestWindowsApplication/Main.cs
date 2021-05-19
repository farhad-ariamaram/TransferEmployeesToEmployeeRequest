using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Extensions.Hosting;
using TransferEmployeesToEmployeeRequestWindowsApplication.EmployReqModels;
using TransferEmployeesToEmployeeRequestWindowsApplication.Models;
using System.Threading;
using System.Threading.Tasks;

namespace TransferEmployeesToEmployeeRequestWindowsApplication
{
    public partial class Main : Form
    {
        private EmployDBContext _db;

        private EmployeeRequestDBContext _db2;

        public Main()
        {
            InitializeComponent();

            _db = new EmployDBContext();
            _db2 = new EmployeeRequestDBContext();

            doProcess();

        }

        public async void doProcess()
        {
            while (true)
            {
                await Task.Delay(1000);
                try
                {
                    var notTransferedUsers = _db.TblUsers.Where(a => a.IsTransfered == false && a.TblPrimaryInformations.FirstOrDefault().TrackNo != null).ToList();

                    if (notTransferedUsers.Any())
                    {
                        foreach (var item in notTransferedUsers)
                        {
                            if (Transfer(item))
                            {
                                item.IsTransfered = true;
                                _db.TblUsers.Update(item);
                                _db.SaveChanges();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                await Task.Delay(900000);
            }
        }

        private bool Transfer(TblUser user)
        {
            #region Transfer
            var t = _db2.TblEmployeeRequestEmployees.Find(user.Id);
            if (t == null)
            {
                TblEmployeeRequestEmployee TblEmployeeRequestEmployee = new TblEmployeeRequestEmployee()
                {
                    FldEmployeeRequestEmployeeId = user.Id,
                    FldEmployeeRequestEmployeeCurrentLevel = user.CurrentLevel,
                    FldEmployeeRequestEmployeePassword = user.Password,
                    FldEmployeeRequestEmployeeUsername = user.Username,
                    FldEmployeeRequestPagesSequenceId = user.PagesSequenceId,
                };
                _db2.TblEmployeeRequestEmployees.Add(TblEmployeeRequestEmployee);


                var TblEmergencyCalls = _db.TblEmergencyCalls.Where(a => a.UserId == user.Id);
                if (TblEmergencyCalls.Any())
                {
                    foreach (var item in TblEmergencyCalls)
                    {
                        TblEmployeeRequestEmergencyCall tblEmployeeRequestEmergencyCall = new TblEmployeeRequestEmergencyCall()
                        {
                            FldEmployeeRequestEmergencyCallDescription = item.Description,
                            FldEmployeeRequestEmergencyCallFirstName = item.FirstName,
                            FldEmployeeRequestEmergencyCallId = item.Id,
                            FldEmployeeRequestEmergencyCallLastName = item.LastName,
                            FldEmployeeRequestEmergencyCallPhoneNo = item.PhoneNo,
                            FldEmployeeRequestEmergencyCallRelative = item.Relative,
                            FldEmployeeRequestEmployeeId = item.UserId
                        };
                        _db2.TblEmployeeRequestEmergencyCalls.Add(tblEmployeeRequestEmergencyCall);
                    }
                }


                var TblCustomerDegrees = _db.TblCustomerDegrees.Where(a => a.UserId == user.Id);
                if (TblCustomerDegrees.Any())
                {
                    foreach (var item in TblCustomerDegrees)
                    {
                        EmployReqModels.TblCustomerDegree TblCustomerDegree = new EmployReqModels.TblCustomerDegree()
                        {
                            UserId = item.UserId,
                            DiplomaId = item.DiplomaId,
                            EducationId = item.EducationId,
                            FldCustomerDegreeId = item.FldCustomerDegreeId,
                            FldDes = item.FldDes,
                            FldEducationName = item.FldEducationName,
                            FldEndDate = item.FldEndDate,
                            FldExportDate = item.FldExportDate,
                            FldExportNo = item.FldExportNo,
                            FldPoint = item.FldPoint,
                            FldStartDate = item.FldStartDate,
                            FldStudyCity = item.FldStudyCity,
                            FldStudyPlace = item.FldStudyPlace
                        };
                        _db2.TblCustomerDegrees.Add(TblCustomerDegree);
                    }
                }


                var TblGeneralRecords = _db.TblGeneralRecords.Where(a => a.UserId == user.Id);
                if (TblGeneralRecords.Any())
                {
                    foreach (var item in TblGeneralRecords)
                    {
                        EmployReqModels.TblEmployeeRequestGeneralRecord TblEmployeeRequestGeneralRecord = new TblEmployeeRequestGeneralRecord()
                        {
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestGeneralRecordCriminalDes = item.CriminalDes,
                            FldEmployeeRequestGeneralRecordCriminalTiltle = item.CriminalTiltle,
                            FldEmployeeRequestGeneralRecordDescription = item.Description,
                            FldEmployeeRequestGeneralRecordId = item.Id
                        };
                        _db2.TblEmployeeRequestGeneralRecords.Add(TblEmployeeRequestGeneralRecord);
                    }
                }


                TblHowFind TblHowFind = _db.TblHowFinds.Where(a => a.UserId == user.Id).FirstOrDefault();
                if (TblHowFind != null)
                {
                    EmployReqModels.TblEmployeeRequestHowFind TblEmployeeRequestHowFind = new TblEmployeeRequestHowFind()
                    {
                        FldEmployeeRequestEmployeeId = TblHowFind.UserId,
                        FldEmployeeRequestHowFindAdditionalDes = TblHowFind.AdditionalDes,
                        FldEmployeeRequestHowFindId = TblHowFind.Id,
                        FldEmployeeRequestHowFindTitle = TblHowFind.HowFindTitle
                    };
                    _db2.TblEmployeeRequestHowFinds.Add(TblEmployeeRequestHowFind);
                }



                var TblIpLogs = _db.TblIpLogs.Where(a => a.UserId == user.Id);
                if (TblIpLogs.Any())
                {
                    foreach (var item in TblIpLogs)
                    {
                        EmployReqModels.TblEmployeeRequestIpLog TblEmployeeRequestIpLog = new TblEmployeeRequestIpLog()
                        {
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestIpLogDateTime = item.DateTime,
                            FldEmployeeRequestIpLogId = item.Id,
                            FldEmployeeRequestIpLogIp = item.Ip
                        };
                        _db2.TblEmployeeRequestIpLogs.Add(TblEmployeeRequestIpLog);
                    }
                }


                var TblMedicalRecords = _db.TblMedicalRecords.Where(a => a.UserId == user.Id);
                if (TblMedicalRecords.Any())
                {
                    foreach (var item in TblMedicalRecords)
                    {
                        EmployReqModels.TblEmployeeRequestMedicalRecord TblEmployeeRequestMedicalRecord = new TblEmployeeRequestMedicalRecord()
                        {
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestMedicalRecordComplicationsDes = item.ComplicationsDes,
                            FldEmployeeRequestMedicalRecordDescription = item.Description,
                            FldEmployeeRequestMedicalRecordDisease = item.Disease,
                            FldEmployeeRequestMedicalRecordEndDate = item.EndDate,
                            FldEmployeeRequestMedicalRecordHasComplications = item.HasComplications,
                            FldEmployeeRequestMedicalRecordHasProblem = item.HasProblem,
                            FldEmployeeRequestMedicalRecordId = item.Id,
                            FldEmployeeRequestMedicalRecordIsAddict = item.IsAddict,
                            FldEmployeeRequestMedicalRecordProblemDes = item.ProblemDes,
                            FldEmployeeRequestMedicalRecordStartDate = item.StartDate
                        };
                        _db2.TblEmployeeRequestMedicalRecords.Add(TblEmployeeRequestMedicalRecord);
                    }
                }


                var TblPageTimeLogs = _db.TblPageTimeLogs.Where(a => a.UserId == user.Id);
                if (TblPageTimeLogs.Any())
                {
                    foreach (var item in TblPageTimeLogs)
                    {
                        EmployReqModels.TblEmployeeRequestPageTimeLog TblEmployeeRequestPageTimeLog = new TblEmployeeRequestPageTimeLog()
                        {
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestPageTimeLogEndTime = item.EndTime,
                            FldEmployeeRequestPageTimeLogStartTime = item.StartTime,
                            FldEmployeeRequestPageTimeLogId = item.Id,
                            FldEmployeeRequestPageTimeLogPageLevel = item.PageLevel
                        };
                        _db2.TblEmployeeRequestPageTimeLogs.Add(TblEmployeeRequestPageTimeLog);
                    }
                }



                TblPrimaryInformation TblPrimaryInformation = _db.TblPrimaryInformations.Where(a => a.UserId == user.Id).FirstOrDefault();
                if (TblPrimaryInformation != null)
                {
                    EmployReqModels.TblEmployeeRequestPrimaryInformation TblEmployeeRequestPrimaryInformation = new TblEmployeeRequestPrimaryInformation()
                    {
                        FldEmployeeRequestEmployeeId = TblPrimaryInformation.UserId,
                        FldEmployeeRequestPrimaryInformationBirthDate = TblPrimaryInformation.BirthDate,
                        FldEmployeeRequestPrimaryInformationChildrenNo = TblPrimaryInformation.ChildrenNo,
                        FldEmployeeRequestPrimaryInformationFirstName = TblPrimaryInformation.FirstName,
                        FldEmployeeRequestPrimaryInformationGender = TblPrimaryInformation.Gender,
                        FldEmployeeRequestPrimaryInformationId = TblPrimaryInformation.Id,
                        FldEmployeeRequestPrimaryInformationLastName = TblPrimaryInformation.LastName,
                        FldEmployeeRequestPrimaryInformationMarital = TblPrimaryInformation.Marital,
                        FldEmployeeRequestPrimaryInformationNationalCode = TblPrimaryInformation.NationalCode,
                        FldEmployeeRequestPrimaryInformationPhoneNo = TblPrimaryInformation.PhoneNo,
                        FldEmployeeRequestPrimaryInformationPostalCode = TblPrimaryInformation.PostalCode,
                        FldEmployeeRequestPrimaryInformationTrackNo = TblPrimaryInformation.TrackNo,
                        FldEmployeeRequestPrimaryInformationTutelage = TblPrimaryInformation.Tutelage
                    };
                    _db2.TblEmployeeRequestPrimaryInformations.Add(TblEmployeeRequestPrimaryInformation);
                }



                var TblUserCompilations = _db.TblUserCompilations.Where(a => a.UserId == user.Id);
                if (TblUserCompilations.Any())
                {
                    foreach (var item in TblUserCompilations)
                    {
                        EmployReqModels.TblEmployeeRequestUserCompilation TblEmployeeRequestUserCompilation = new TblEmployeeRequestUserCompilation()
                        {
                            FldEmployeeRequestCompilationTypeId = item.CompilationTypeId,
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestUserCompilationAuthor = item.Author,
                            FldEmployeeRequestUserCompilationDate = item.Date,
                            FldEmployeeRequestUserCompilationDescription = item.Description,
                            FldEmployeeRequestUserCompilationExplanation = item.Explanation,
                            FldEmployeeRequestUserCompilationId = item.Id,
                            FldEmployeeRequestUserCompilationTitle = item.Title
                        };
                        _db2.TblEmployeeRequestUserCompilations.Add(TblEmployeeRequestUserCompilation);
                    }
                }



                var TblUserCreativitys = _db.TblUserCreativities.Where(a => a.UserId == user.Id);
                if (TblUserCreativitys.Any())
                {
                    foreach (var item in TblUserCreativitys)
                    {
                        EmployReqModels.TblEmployeeRequestUserCreativity TblEmployeeRequestUserCreativity = new TblEmployeeRequestUserCreativity()
                        {
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestCreativityTypeId = item.CreativityTypeId,
                            FldEmployeeRequestUserCreativityDate = item.Date,
                            FldEmployeeRequestUserCreativityDescription = item.Description,
                            FldEmployeeRequestUserCreativityExplanation = item.Explanation,
                            FldEmployeeRequestUserCreativityId = item.Id,
                            FldEmployeeRequestUserCreativityTitle = item.Title
                        };
                        _db2.TblEmployeeRequestUserCreativities.Add(TblEmployeeRequestUserCreativity);
                    }
                }



                var TblUserJobs = _db.TblUserJobs.Where(a => a.UserId == user.Id);
                if (TblUserJobs.Any())
                {
                    foreach (var item in TblUserJobs)
                    {
                        EmployReqModels.TblEmployeeRequestUserJob TblEmployeeRequestUserJob = new TblEmployeeRequestUserJob()
                        {
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestJobsId = item.JobsId,
                            FldEmployeeRequestUserJobDescription = item.Description,
                            FldEmployeeRequestUserJobId = item.Id,
                            FldEmployeeRequestUserJobRequestMoney = item.RequestMoney,
                            FldEmployeeRequestUserJobTitle = item.JobTitle,
                            FldEmployeeRequestUserJobWhatKnowAbout = item.WhatKnowAbout
                        };
                        _db2.TblEmployeeRequestUserJobs.Add(TblEmployeeRequestUserJob);
                    }
                }



                var TblUserLanguages = _db.TblUserLanguages.Where(a => a.UserId == user.Id);
                if (TblUserLanguages.Any())
                {
                    foreach (var item in TblUserLanguages)
                    {
                        EmployReqModels.TblEmployeeRequestUserLanguage TblEmployeeRequestUserLanguage = new TblEmployeeRequestUserLanguage()
                        {
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestUserLanguageDescription = item.Description,
                            FldEmployeeRequestUserLanguageId = item.Id,
                            FldEmployeeRequestUserLanguageLanguageTypeId = item.LanguageTypeId,
                            FldEmployeeRequestUserLanguageListeningLevel = item.ListeningLevel,
                            FldEmployeeRequestUserLanguageReadingLevel = item.ReadingLevel,
                            FldEmployeeRequestUserLanguageSpeakingLevel = item.SpeakingLevel,
                            FldEmployeeRequestUserLanguageWritingLevel = item.WritingLevel,
                            FldEmployeeRequestUserLanguageIsNative = item.IsNative
                        };
                        _db2.TblEmployeeRequestUserLanguages.Add(TblEmployeeRequestUserLanguage);
                    }
                }



                TblUserMilitary TblUserMilitary = _db.TblUserMilitaries.Where(a => a.UserId == user.Id).FirstOrDefault();
                if (TblUserMilitary != null)
                {
                    if (TblUserMilitary != null)
                    {
                        EmployReqModels.TblEmployeeRequestUserMilitary TblEmployeeRequestUserMilitary = new TblEmployeeRequestUserMilitary()
                        {
                            FldEmployeeRequestEmployeeId = TblUserMilitary.UserId,
                            FldEmployeeRequestMilitaryId = TblUserMilitary.MilitaryId,
                            FldEmployeeRequestMilitaryOrganizationId = TblUserMilitary.OrganizationId,
                            FldEmployeeRequestUserMilitaryCity = TblUserMilitary.City,
                            FldEmployeeRequestUserMilitaryDescription = TblUserMilitary.Description,
                            FldEmployeeRequestUserMilitaryEndDate = TblUserMilitary.EndDate,
                            FldEmployeeRequestUserMilitaryExemptDescription = TblUserMilitary.ExemptDescription,
                            FldEmployeeRequestUserMilitaryId = TblUserMilitary.Id,
                            FldEmployeeRequestUserMilitaryStartDate = TblUserMilitary.StartDate,
                            FldEmployeeRequestUserMilitaryUnit = TblUserMilitary.Unit
                        };
                        _db2.TblEmployeeRequestUserMilitaries.Add(TblEmployeeRequestUserMilitary);
                    }
                }




                var TblUserSkills = _db.TblUserSkills.Where(a => a.UserId == user.Id);
                if (TblUserSkills.Any())
                {
                    foreach (var item in TblUserSkills)
                    {
                        EmployReqModels.TblEmployeeRequestUserSkill TblEmployeeRequestUserSkill = new TblEmployeeRequestUserSkill()
                        {
                            FldEmployeeRequestEmployeeId = item.UserId,
                            FldEmployeeRequestSkillsId = item.SkillId,
                            FldEmployeeRequestUserSkillDate = item.Date,
                            FldEmployeeRequestUserSkillDescription = item.Description,
                            FldEmployeeRequestUserSkillId = item.Id,
                            FldEmployeeRequestUserSkillIsSelfTaught = item.IsSelfTaught,
                            FldEmployeeRequestUserSkillLicenseNo = item.LicenseNo,
                            FldEmployeeRequestUserSkillLicenseReference = item.LicenseReference,
                            FldEmployeeRequestUserSkillLocation = item.Location,
                            FldEmployeeRequestUserSkillSkillLevel = item.SkillLevel,
                            FldEmployeeRequestUserSkillSkillTitle = item.SkillTitle,
                            FldEmployeeRequestUserSkillSkillType = item.SkillType
                        };
                        _db2.TblEmployeeRequestUserSkills.Add(TblEmployeeRequestUserSkill);
                    }
                }

                List<long> weids = new List<long>();
                var TblWorkExperiences = _db.TblWorkExperiences.Where(a => a.UserId == user.Id);
                if (TblWorkExperiences.Any())
                {
                    foreach (var item in TblWorkExperiences)
                    {
                        weids.Add(item.FldWorkExperienceId);
                        EmployReqModels.TblWorkExperience TblWorkExperience = new EmployReqModels.TblWorkExperience()
                        {
                            FldAmountOfDailyInsurance = item.FldAmountOfDailyInsurance,
                            FldCompanyName = item.FldCompanyName,
                            FldContactInnerNumberOfCompany = item.FldContactInnerNumberOfCompany,
                            FldContactNumberOfCompany = item.FldContactNumberOfCompany,
                            FldCustomerName = item.FldCustomerName,
                            FldDescription = item.FldDescription,
                            FldEarlySalary = item.FldEarlySalary,
                            FldEndDate = item.FldEndDate,
                            FldJobTitle = item.FldJobTitle,
                            FldLateSalary = item.FldLateSalary,
                            FldLeaveJobId = item.FldLeaveJobId,
                            FldReasonsToLeaveJob = item.FldReasonsToLeaveJob,
                            FldRelatedPeople = item.FldRelatedPeople,
                            FldStartDate = item.FldStartDate,
                            FldTaminJobId = item.FldTaminJobId,
                            FldUnitName = item.FldUnitName,
                            FldWorkDay = item.FldWorkDay,
                            FldWorkExperienceId = item.FldWorkExperienceId,
                            FldWorkTime = item.FldWorkTime,
                            HasInsurance = item.HasInsurance,
                            InsuranceNo = item.InsuranceNo,
                            IsWorking = item.IsWorking,
                            PreviousJobAchievements = item.PreviousJobAchievements,
                            UserId = item.UserId,
                            WhyWantChangeJob = item.WhyWantChangeJob,
                        };
                        _db2.TblWorkExperiences.Add(TblWorkExperience);
                    }
                }

                if (weids.Any())
                {
                    foreach (var item in weids)
                    {
                        var TblWorkExperienceLeaveJobDtls = _db.TblWorkExperienceLeaveJobDtls.Where(a => a.FldWorkExperienceId == item);
                        if (TblWorkExperienceLeaveJobDtls.Any())
                        {
                            foreach (var item2 in TblWorkExperienceLeaveJobDtls)
                            {
                                EmployReqModels.TblWorkExperienceLeaveJobDtl TblWorkExperienceLeaveJobDtl = new EmployReqModels.TblWorkExperienceLeaveJobDtl()
                                {
                                    FldLeaveJobId = item2.FldLeaveJobId,
                                    FldLeaveJobPercent = item2.FldLeaveJobPercent,
                                    FldWorkExperienceId = item2.FldWorkExperienceId,
                                    FldWorkExperienceLeaveJobDtlId = item2.FldWorkExperienceLeaveJobDtlId,
                                    FldLeaveJob = item2.FldLeaveJob
                                };
                                _db2.TblWorkExperienceLeaveJobDtls.Add(TblWorkExperienceLeaveJobDtl);
                            }
                        }
                    }
                }

                _db2.SaveChanges();
            }
            #endregion

            return true;
        }
    }
}
