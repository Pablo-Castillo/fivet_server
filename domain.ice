/*
 * MIT License
 *
 * Copyright (c) 2020 Pablo-Castillo <pablo.castillo01@alumnos.ucn.cl>.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

// https://doc.zeroc.com/ice/3.7/language-mappings/java-mapping/client-side-slice-to-java-mapping/customizing-the-java-mapping
["java:package:cl.ucn.disc.pdis.fivet.zeroice", "cs:namespace:Fivet.ZeroIce"]
module model {


    /**
    *Clase Persona
    */
    ["cs:property"]
    class Persona{

        /**
        *PK
        */
        int uid;

        /**
        *Nombre: Pablo
        */
        string nombre;

        /**
        *Apellido: Castillo
        */
        string apellido;

        /**
        *Rut: 182335622
        */
        string rut;

        /**
        *Direccion: unadireccion #7649
        */
        string direccion;

        /**
        *Telefono Fijo: +56 55 2785738
        */
        long telefonoFijo;

        /**
        *Celular: +56948729563
        */
        long celular;

        /**
        *Email: unemail@email.com
        */
        string email;
    }

    /**
    *Tipo de paciente
    */
    enum tipoPaciente {
        INTERNO,
        EXTERNO
    }

    /**
    *Sexo de paciente
    */
    enum Sexo {
        MACHO,
        HEMBRA
    }

    /**
    *Clase Ficha
    */
    ["cs:property"]
    class Ficha{

        /**
        *PK
        */
        int uid;

        /**
        *Numero de ficha
        */
        int nFicha;

        /**
        *Nombre Paciente: Leonidas
        */
        string nombPaciente;

        /**
        *Especie: Perro/gato/etc
        */
        string especie;

        /**
        *Fecha de Nacimiento: dia/mes/año
        */
        string nacimiento;

        /**
        *Raza: Labrador
        */
        string raza;

        /**
        *Sexo: Macho/Hembra
        */
        Sexo sexo;

        /**
        *Color: Negro
        */
        string color;

        /**
        *Tipo: Interno/Externo
        */
        tipoPaciente tipoPaciente;
    }

    /**
    *Clase Control
    */
    ["cs:property"]
    class Control{
        /**
        *PK
        */
        int uid;

        /**
        *Fecha: dia/mes/año
        */
        string fecha;

        /**
        *Proximo Control: dia/mes/año
        */
        string proxControl;

        /**
        *Temperatura: 36°
        */
        int temperatura;

        /**
        *Peso: 30 Kg
        */
        double peso;

        /**
        *Altura: 60 cm
        */
        double altura;

        /**
        *Diagnostico: Problemas digestivos
        */
        string diagnostico;

        /**
        *Veterinario: Carlos Vidal Pinto
        */
        string veterinario;

    }

    /**
    *Clase Examen
    */
    ["cs:property"]
    class Examen{
        /**
        *PK
        */
        int uid;

        /**
        *Nombre del Examen: Radiografia
        */
        string nomExamen;

        /**
        *Fecha del examen: dia/mes/año
        */
        string feExamen;
    }

    /**
    *Clase Foto
    */
    ["cs:property"]
    class Foto{
        /**
        *Foto: URL de la foto
        */
        string foto;
    }

    /**
    *Contratos
    */

    interface Contratos {
        /**
         *
         * @param ficha a crear.
         * @return ficha creada
         */
        Ficha crearFicha(Ficha ficha);

        /**
         *
         * @param persona a crear
         * @return Persona creada
         */
        Persona crearPersona(Persona persona);

        /**
         *
         * @param numFicha para identificar el control.
         * @param control a crear.
         */
        Control crearControl(int numFicha, Control control);

        /**
         *
         * @param numero de la ficha a buscar.
         * @return Ficha buscada.
         */
        Ficha obtenerFicha(int numero);

        /**
         *
         * @param rut de la persona a buscar.
         * @return Persona buscada.
         */
        Persona obtenerPersona(string rut);
    }


    /**
     * The base system.
     */
     interface TheSystem {

        /**
         * @return the diference in time between client and server.
         */
        long getDelay(long clientTime);

     }

}
