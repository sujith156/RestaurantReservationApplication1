using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.ServiceModel.Web;

namespace RESTApp1
{
    [ServiceContract]
    public interface IReservationService
    {
        /*
             * WEB METHOD TO VIEW ALL RESERVATIONS
             * RETURNS AL RESERVATIONS  DETAILS IN THE FORM OF
             * JSON OBJECTS 
         */
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/api/ViewReservations"
            )]
        List<tblreservation> ViewReservations();      

        /*
            * WEB METHOD TO VIEW RESERVATION BY ID
            * TAKES RESERVATION ID AS INPUT AND RETURNS THE 
            * RESERVATION DETAILS IN JSON 
        */
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/api/ViewReservation/{id}"
            )]
        tblreservation ViewReservation(string id);

        /*
             * WEB METHOD TO CREATE A NEW RESERVATION WHEN AUTO ASSIGN IS ON
             * TAKES RESERVATION OBJECT AS INPUT AND 
             * RETURNS RESERVATION ID IN JSON 
         */
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/api/CreateReservation/"
            )]
        int CreateReservation(tblreservation res);


        /*
             * WEB METHOD TO CREATE A NEW RESERVATION WHEN AUTO ASSIGN IS OFF
             * TAKES RESERVATION OBJECT AND TABLE NUMBER AS INPUT
             * RETURNS ID IN JSON
         */
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/api/CreateReservation_AutoAssignOff/{tableno}"
            )]

        int CreateReservation_AutoAssignOff(tblreservation res, string tableno);

        /*
            * WEB METHOD TO UPDATE AN EXISTING RESERVATION 
            * TAKES RESERVATION OBJECT AS INPUT
            * RETURNS ID IN JSON
        */
        [OperationContract]
        [WebInvoke(Method = "PUT",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "/api/UpdateReservation/{id}")]
        int UpdateReservation(tblreservation res, string id);

        /*
            * WEB METHOD TO CANCEL AN EXISTING RESERVATION 
            *  TAKES RESERVATION ID AS INPUT
            *  RETURNS STATUS
        */
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/api/CancelReservation/{id}"
            )]
        string CancelReservation(string id);


        /*
             * WEB METHOD TO VIEW PROFILE OF THE OWNER
             * RETURNS THE PROFILE DETAILS IN JSON 
        */
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/api/ViewProfile/"
            )]
        List<tblProfile> ViewProfile();


       /*
            * WEB METHOD TO UPDATE AN EXISTING PROFILE 
            * TAKES PROFILE OBJECT AS INPUT
            * RETURNS EMAIL IN JSON
        */
            [OperationContract]
            [WebInvoke(Method = "PUT",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/api/UpdateProfile/")]
            string UpdateProfile(tblProfile prof);

        /*
         * WEB METHOD TO ASSIGN A TABLE TO AN EXISTING RESERVATION
         * 
         */

            [OperationContract]
            [WebInvoke(Method = "PUT",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "/api/Assign_table/{tableno}"
                )]

            List<tbltable> Assign_table(string tableno,int id,string time);



        //WEB METHOD TO LOGIN THE ADMIN

            [OperationContract]
            [WebInvoke(Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "/api/admin_login/{email}/{password}"
                )]

            string admin_login(string email, string password);

            [OperationContract]
            [WebInvoke(Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "/api/ViewContacts"
                )]

           List<tblreservation> ViewContacts();

    }
}
