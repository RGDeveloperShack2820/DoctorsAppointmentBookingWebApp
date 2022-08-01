using DoctorsAppointmentModelLibrary.ApiModels;
using DoctorsAppointmentModelLibrary.EntityModels;
using DoctorsAppointmentModelLibrary.MVCModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DoctorsAppointmentBookingMVC.Helpers
{
    public class WebApiHelper
    {
        Uri apiBaseAddress;
        RestClient restClient;
        IRestRequest request;
        
        public WebApiHelper()
        {
            apiBaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiUrl"]);
            restClient = new RestClient(apiBaseAddress);
        }

        public int GetUserIdMVC(string email = "", string password = "")
        {

            int id = 0;

            request = new RestRequest("UserApiModals", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddQueryParameter("email", email);
            request.AddQueryParameter("password", password);

            try
            {
                var response =restClient.Execute<int>(request);
                id = response.Data;
            }
            catch (Exception){}

            return id;

           
        }

            public UserMVC GetUserMVC(int id)
        {
            string suffix = $"UserApiModals/{id}";

            request = new RestRequest(suffix, Method.GET) { RequestFormat = DataFormat.Json };

            var response = restClient.Execute<UserApiModal>(request);

                UserApiModal userApiModal = response.Data;

                UserMVC userMVC=new UserMVC();
                userMVC.id=userApiModal.id;
                userMVC.name=userApiModal.name;
                userMVC.email=userApiModal.email;
                userMVC.department=userApiModal.department;
                userMVC.password=userApiModal.password;


            return userMVC;
        }

        public List<AppointmentMVC> GetAppointmentMVC()
        {
            string suffix = $"AppointmentApiModals/"; ;

            request = new RestRequest(suffix, Method.GET) { RequestFormat = DataFormat.Json };
            var response = restClient.Execute<List<AppointmentApiModal>>(request);

            List<AppointmentApiModal> list = response.Data;
            List<AppointmentMVC> mvcList=new List<AppointmentMVC>();
            
            foreach(AppointmentApiModal appApiModal in list)
            {
                AppointmentMVC appointmentMVC = new AppointmentMVC()
                {
                       id = appApiModal.id,
                       time = appApiModal.time,
                       patient = GetUserMVC(appApiModal.patient),
                       doctor = GetUserMVC(appApiModal.doctor)
                };

                mvcList.Add(appointmentMVC);
            }


            
            return mvcList;
        }


        public void PostRequest(UserMVC userMVC)
        {
            UserApiModal userApiModal = new UserApiModal()
            {
                id=userMVC.id,
                email=userMVC.email,
                name=userMVC.name,
                password=userMVC.password,
                department=userMVC.department,
            };

            string suffix = $"UserApiModals/" ;

            request = new RestRequest(suffix, Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(userApiModal);

            var response = restClient.Execute<UserApiModal>(request);

            UserApiModal userApi = response.Data;

        }

        public void DeleteAppointment(int id)
        {
            string suffix = $"AppointmentApiModals/{id}";

            request = new RestRequest(suffix, Method.DELETE) { RequestFormat = DataFormat.Json };
            var response = restClient.Execute<Appointment>(request);

            Appointment appointment = response.Data;

        }

        public AppointmentApiModal PostAppointment(AppointmentApiModal appointmentApiModal)
        {
            string suffix = $"AppointmentApiModals/";

            request = new RestRequest(suffix, Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(appointmentApiModal);

            var response = restClient.Execute<AppointmentApiModal>(request);

            AppointmentApiModal appointment = response.Data;

            return appointment;
        }

        public List<UserMVC> GetDoctors()
        {
            string suffix = $"UserApiModals/";

            request = new RestRequest(suffix, Method.GET) { RequestFormat = DataFormat.Json };

            var response = restClient.Execute<List<UserApiModal>>(request);

            List<UserApiModal> apiList = response.Data;
            List<UserMVC> mvcList=new List<UserMVC>();


            foreach (UserApiModal userApiModal in apiList)
            {
                UserMVC userMVC = new UserMVC();
                userMVC.id = userApiModal.id;
                userMVC.name = userApiModal.name;
                userMVC.email = userApiModal.email;
                userMVC.department = userApiModal.department;
                userMVC.password = userApiModal.password;

                mvcList.Add(userMVC);
            }

            return mvcList;

        }
    }
}