using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instanciables;
using Excepciones;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarNacionalidadInvalidaException()
        {
            try
            {
                Alumno a1 =new Alumno(1, "Angel", "Gutenberg", "28222333", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
                Assert.Fail("SE DEBE LANZAR UN ERROR DE INCONSISTENCIA RESPECTO A LA NACIONALIDAD");
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsTrue(true);
            }


        }

        [TestMethod]
        public void validarValorNumerico()
        {
            Profesor p1 = new Profesor(3, "Ariel", "SCHUTZ", "12222333", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Assert.IsInstanceOfType(p1.DNI, typeof(int));
        }

        [TestMethod]
        public void validarAtributoColeccion()
        {
            Universidad u1 = new Universidad();
            List<Alumno> alumnos = u1.Alumnos;

            Assert.IsNotNull(alumnos);
        }
    }
}
