using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen_Measurement
{
    enum Measurement_Class_t
    {
        Count   =   1,
        Mass    =   2,
        Volume  =   3
    }

    enum Measurement_Unit_t
    {
        //Count Units
        Units   =   0x11,
        Custom  =   0x12,

        //Mass Units
        grams       =   0x21,
        Kilograms   =   0x22,
        ounce       =   0x23,
        Pounds      =   0x24,
            
        //Volumetric Units
        fl_oz   =   0x31,
        tsp     =   0x32,
        tbsp    =   0x33,
        Cup     =   0x34,
        Quart   =   0x35,
        Gallon  =   0x36
    }

    struct Measurement_t
    {

        float m_fAmount;
        Measurement_Class_t m_MeasurementClass;
        Measurement_Unit_t m_UnitOfMeasurement;

        //  Constructors    ///////////////////////////////////////////////////////////////////////

        public Measurement_t(float fAmount,
                            Measurement_Class_t MeasurementClass = Measurement_Class_t.Count, 
                            Measurement_Unit_t UnitOfMeasurement = Measurement_Unit_t.Units)
        {
            m_fAmount = fAmount;
            m_MeasurementClass = MeasurementClass;
            m_UnitOfMeasurement = UnitOfMeasurement;
        }

        //  Public Functions    ///////////////////////////////////////////////////////////////////

        public static Measurement_t operator + (Measurement_t rhs, Measurement_t lhs)
        {
            //Check for class of measurement
            if(rhs.m_MeasurementClass != lhs.m_MeasurementClass)
            {
                //Convert
            }

            //Now create new measurement with the combined values and return
            return new Measurement_t((rhs.m_fAmount + lhs.m_fAmount), rhs.m_MeasurementClass, rhs.m_UnitOfMeasurement);
        }

        public static Measurement_t operator -(Measurement_t rhs, Measurement_t lhs)
        {
            //Check for class of measurement
            if (rhs.m_MeasurementClass != lhs.m_MeasurementClass)
            {
                //Convert
            }

            //Now create new measurement with the combined values and return
            return new Measurement_t((rhs.m_fAmount - lhs.m_fAmount), rhs.m_MeasurementClass, rhs.m_UnitOfMeasurement);
        }
    }
  
}
