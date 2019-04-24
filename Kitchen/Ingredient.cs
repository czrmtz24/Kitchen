using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen_Inventory
{
    public class Measurement
    {
        //  Members ///////////////////////////////////////////////////////////////////////////////

        private float m_fAmount;
        private string m_sUnitsOfMeasurement;

        //  Constructors    ///////////////////////////////////////////////////////////////////////

        public Measurement(float fNewAmount, string sNewUnitsOfMeasurement)
        {
            m_fAmount = fNewAmount;
            m_sUnitsOfMeasurement = sNewUnitsOfMeasurement;
        }

        public Measurement(Measurement M)
        {
            m_fAmount = M.MeasurementAmount;
            m_sUnitsOfMeasurement = M.UnitsOfMeasurement;
        }

        //  Properties  ///////////////////////////////////////////////////////////////////////////

        public float MeasurementAmount
        {
            get { return m_fAmount; }
            set { m_fAmount = value; }
        }

        public string UnitsOfMeasurement
        {
            get { return m_sUnitsOfMeasurement; }
            set { m_sUnitsOfMeasurement = value; }
        }

        //  Public Functions    ///////////////////////////////////////////////////////////////////

        public static implicit operator float (Measurement measurement)
        {
            return measurement.MeasurementAmount;
        }

        public static implicit operator Measurement(float fValue)
        {
            return new Measurement(fValue, "Units");
        }

        public static Measurement operator +(Measurement rhs, float lhs)
        {
            return new Measurement((rhs.MeasurementAmount + lhs), rhs.UnitsOfMeasurement);
        }

        public static Measurement operator -(Measurement rhs, float lhs)
        {
            return new Measurement((rhs.MeasurementAmount - lhs), rhs.UnitsOfMeasurement);
        }
    }

    public class Ingredient
    {
        //  Members ///////////////////////////////////////////////////////////////////////////////

        private string m_sDescription, m_sName;
        private Measurement m_Amount;

        //  Constructors    ///////////////////////////////////////////////////////////////////////

        public Ingredient(Measurement amount, string sDescription, string sName)
        {
            m_Amount = amount;
            m_sDescription = sDescription;
            m_sName = sName;
        }

        //  Properties  ///////////////////////////////////////////////////////////////////////////

        public Measurement Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }

        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }
        
        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

    }
}
