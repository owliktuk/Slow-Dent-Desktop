using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slow_Dent_Desktop
{
    [Serializable]
    abstract public class Person
    {
        public string itsName { get; set; }
        public string itsSurname { get; set; }
        public string itsPESEL { get; set; }
        public Address itsAddress { get; set; }
        public string itsTelephone { get; set; }
        public string itsBirthDate { get; set; }
    }

    [Serializable]
    public class Patient : Person
    {
        public int PatientId { get; set; }
        public List<Tooth> itsTeeth { get; set; }
        public virtual List<TreatmentHistory> itsTreatments { get; set; }
        public virtual List<TreatmentPlans> itsTreatmentPlans { get; set; }
        public virtual List<Disease> itsDiseases { get; set; }
        public bool isPregnant { get; set; }
        public string addInfo { get; set; }
        public string Drugs { get; set; }


        public Patient()
        {

        }

        public Patient(string name, string surname, string pesel, Address address, string tel, string birth)
        {
            itsName = name;
            itsSurname = surname;
            itsPESEL = pesel;
            itsAddress = address;
            itsTelephone = tel;
            itsBirthDate = birth;
            itsTreatments = new List<TreatmentHistory>();
            itsTreatmentPlans = new List<TreatmentPlans>();
            itsDiseases = new List<Disease>();
            itsTeeth = new List<Tooth>();



            for (int i = 1; i <= 4; i++)
            {
                for(int j = 1; j <= 8; j++)
                {
                    itsTeeth.Add(new Tooth(i.ToString() + j.ToString()));
                }                
            }

            for (int i = 5; i <= 8; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    itsTeeth.Add(new Tooth(i.ToString() + j.ToString()));
                }
            }

        }


        public Tooth getTooth(string TId)
        {
            return itsTeeth.Where(dt => String.Equals(TId, dt.ToothPosition)).Single();
        }

        public void synchronizeTreatments()
        {
            int n = itsTreatmentPlans.Count();

            System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");
            for (int i=0; i < n; i++)
            {
                DateTime Date = DateTime.ParseExact(itsTreatmentPlans[i].itsDate + " " + itsTreatmentPlans[i].itsHour, "dd-MM-yyyy HH:mm", enUS);

                if(Date < DateTime.Now)
                {
                    TreatmentHistory treat = new TreatmentHistory();
                    treat.copyFromPlans(itsTreatmentPlans[i]);                
                    itsTreatments.Add(treat);
                    itsTreatmentPlans.RemoveAt(i);
                }
            }
        }

    }

    [Serializable]
    public class Tooth
    {
        public int ToothId { get; set; }
        public string ToothPosition { get; set; }

        private bool _hasCrown;
        private bool _isEndo;
        private bool _isExtracted;
        private bool _isCutting;
        private bool _isStopped;

        public virtual Patient itsPatient { get; set; }


        public bool hasCrown
        {
            get
            {
                return _hasCrown;
            }
            set
            {
                if (value == true)
                    _isCutting = _isExtracted = _isStopped = false;
                _hasCrown = value;
            }
        }
        public bool isEndo
        {
            get
            {
                return _isEndo;
            }
            set
            {
                if (value == true)
                    _isCutting = _isExtracted = _isStopped = false;
                _isEndo = value;
            }
        }
        public bool isExtracted
        {
            get
            {
                return _isExtracted;
            }
            set
            {
                if (value == true)
                    _isCutting = _isEndo = _hasCrown = _isStopped = false;
                _isExtracted = value;
            }
        }
        public bool isCutting
        {
            get
            {
                return _isCutting;
            }
            set
            {
                if (value == true)
                    _isExtracted = _hasCrown = _isEndo = _isStopped = false;
                _isCutting = value;
            }
        }
        public bool isStopped
        {
            get
            {
                return _isStopped;
            }
            set
            {
                if (value == true)
                    _isExtracted = _hasCrown = _isEndo = _isCutting = false;
                _isStopped = value;
            }
        }

        
        
        public ToothRegion farther { get; set; }
        public ToothRegion closer { get; set; }
        public ToothRegion top { get; set; }
        public ToothRegion buccal { get; set; }
        public ToothRegion palatal { get; set; }

        public Tooth()
        { }

        public Tooth(string id)
        {
            ToothPosition = id;

            farther = new ToothRegion("farther", false, false);
            closer = new ToothRegion("closer", false, false);
            top = new ToothRegion("top", false, false);
            buccal = new ToothRegion("buccal", false, false);
            palatal = new ToothRegion("palatal", false, false);



        }

        public bool isHealthy()
        {
            if (farther.hasCavity == closer.hasCavity == top.hasCavity == buccal.hasCavity == palatal.hasCavity == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isNormal()
        {
            if(hasCrown == isEndo == isCutting == isExtracted == isStopped == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setNormal()
        {
            hasCrown = isEndo = isCutting = isExtracted = isStopped = false;
        }

        public ToothRegion getRegion(string region)
        {
            switch(region)
            {
                case "farther":
                    return farther;
                case "closer":
                    return closer;
                case "top":
                    return top;
                case "buccal":
                    return buccal;
                case "palatal":
                    return palatal;
                default:
                    return null;
            }
        }


    }

    [Serializable]
    public class ToothRegion
    {
        public string itsRegion { get; }
        public bool hasCavity { get; set; }
        public bool hasFulfillment { get; set; }

        public ToothRegion()
        { }

        public ToothRegion(string region, bool cavity, bool fulfillment)
        {
            itsRegion = region;
            hasCavity = cavity;
            hasFulfillment = fulfillment;
        }

    }

    [Serializable]
    public class Disease
    {
        public int DiseaseId { get; set; }
        public string itsName { get; set; }

        public Disease()
        { }

        public Disease(string name)
        {
            itsName = name;
        }

        public static bool operator ==(Disease a, Disease b)
        {
            return a.itsName == b.itsName;
        }

        public static bool operator !=(Disease a, Disease b)
        {
            return a.itsName != b.itsName;
        }
    }

    [Serializable]
    public class Treatment
    {
        //public int TreatmentId { get; set; }
        public string itsDate { get; set; }
        public string itsHour { get; set; }
        public string RefTooth { get; set; }    
        public string itsDescription { get; set; }

    }

    [Serializable]
    public class TreatmentHistory : Treatment
    {
        public int TreatmentHistoryId { get; set; }
        public string Recognition { get; set; }

        public virtual Patient Patient { get; set; }

        public void copyFromPlans(TreatmentPlans treatmentPlan)
        {
            itsDate = treatmentPlan.itsDate;
            itsHour = treatmentPlan.itsHour;
            itsDescription = treatmentPlan.itsDescription;
            RefTooth = treatmentPlan.RefTooth;
        }
    }

    [Serializable]
    public class TreatmentPlans : Treatment
    {
        public int TreatmentPlansId { get; set; }

        public virtual Patient Patient { get; set; }
    }

    [Serializable]
    public class Address
    {
        public string itsStreet { get; set; }
        public string itsStreetNumber { get; set; }
        public string itsCity { get; set; }
        public string itsPostCode { get; set; }
        public string itsCountry { get; set; }

        public Address()
        {

        }

        public Address(string street, string number, string code, string city, string country)
        {
            itsStreet = street;
            itsStreetNumber = number;
            itsCity = city;
            itsPostCode = code;
            itsCountry = country;
        }

    }
}
