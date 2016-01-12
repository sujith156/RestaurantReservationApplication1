using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTApp1
{
    public class ReservationService : IReservationService
    {
        //IMPLEMENTATION OF ALL WEB METHODS SPECIFIED IN THE SERVICE CONTRACT
        ReservationDBContext ReservationDbcontext = new ReservationDBContext();
        public List<tblreservation> ViewReservations()
        {
            return ReservationDbcontext.tblreservations.ToList();            
        }

        public tblreservation ViewReservation(string Id)
        {
            int QString = Int32.Parse(Id); 
            return ReservationDbcontext.tblreservations.Single(x => x.id == QString);            
        }

        public int CreateReservation(tblreservation res) 
        {
            ReservationDbcontext.spAddReservation(res.name,res.email,res.phonenumber,res.date,res.time,res.partysize,res.specialnotes);
            return res.id;
        }

        public int CreateReservation_AutoAssignOff(tblreservation res, string tableno)
        {
            int tbleno = int.Parse(tableno);
            ReservationDbcontext.spAddReservation_AutoAssignOff(res.name, res.email, res.phonenumber, res.date, res.time, res.partysize, res.specialnotes, tbleno);
            return res.id;
        }

        public int UpdateReservation(tblreservation res, string id) 
        {
            int ID = int.Parse(id);
            ReservationDbcontext.spUpdateReservation(ID, res.name, res.email, res.phonenumber, res.date, res.time, res.partysize, res.specialnotes);           
            return ID;
        }

        public string CancelReservation(string id) 
        {
            int ID = int.Parse(id);
            var result = ReservationDbcontext.spCancelReservation(ID);   
            return id;
        }

        public List<tblProfile> ViewProfile()
        {
            return ReservationDbcontext.tblProfiles.ToList();
        }
        public string UpdateProfile(tblProfile prof)
        {
            ReservationDbcontext.spUpdateProfile(prof.name, prof.email, prof.contactno, prof.autoassign, prof.RestaurantAddress, prof.timings);
            return prof.email;
        }

       
        public List<tbltable> Assign_table(string tableno, int id, string time)
        {
            int table = int.Parse(tableno);
            ReservationDbcontext.spAssigntable(table,time,id );
            return ReservationDbcontext.tbltables.ToList();       
        } 

        public string admin_login(string email, string password)
        {
            var result = ReservationDbcontext.spAuthenticateUser(email, password);
            return result.ToString();
        }


        public List<tblreservation> ViewContacts()
        {
            return ReservationDbcontext.tblreservations.Select(x => new tblreservation { name = x.name, email = x.email, phonenumber = x.phonenumber }).ToList(); 
        }
    }
}

