using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Final.Models.Personas
{
    public class cat_personas
    {
        [PrimaryKey, AutoIncrement]
        public int IdPersona { get; set; }
        public string NumControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string FechaNac { get; set; }
        public bool TipoPersona { get; set; }
        public bool Sexo { get; set; }
        public string RutaFoto { get; set; }
        public string Alias { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        //FK
        [Indexed]
        public int IdInstituto { get; set; }
        [Indexed]
        public int IdTipoGenOcupacion { get; set; }
        [Indexed]
        public int IdGenOcupacion { get; set; }
        [Indexed]
        public int IdTipoGenEstadoCivil { get; set; }
        [Indexed]
        public int IdGenEstadoCivil { get; set; }

        public override string ToString()
        {
            return string.Format("[cat_personas: IdInstituto={0}, IdTipoGenOcupacion={1}, IdGenOcupacion={2}, IdTipoGenEstadoCivil={3}," +
                " IdGenEstadoCivil={4}], NumControl={5},  Nombre={6}, ApPaterno={7}, ApMaterno={8}, RFC={9}, " +
                " CURP={10}, FechaNac={11}, TipoPersona={12}, Sexo={13}, RutaFoto={14}, Alias={15}, FechaReg={16}," +
              " UsuarioReg={17}, FechaUltMod={18}, UsuarioMod={19}, Activo={20}, Borrado={21}",
                               " IdPersona={22}",
                                 IdInstituto, IdTipoGenOcupacion, IdGenOcupacion, IdTipoGenEstadoCivil, IdGenEstadoCivil,
                                NumControl, Nombre, ApPaterno, ApMaterno, RFC, CURP, FechaNac, TipoPersona, Sexo,
                                RutaFoto, Alias, FechaReg, UsuarioReg, FechaUltMod, UsuarioMod, Activo, Borrado
                                 , IdPersona);
        }
    }

    public class rh_cat_dir_web
    {
        [PrimaryKey, Unique]
        public int IdDirWeb { get; set; }
        public string DesDirWeb { get; set; }
        public string DirWeb { get; set; }
        public bool Principal { get; set; }
        public int IdTipoGenDirWeb { get; set; }
        public int IdGenDirWeb { get; set; }
        public string ClaveReferencia { get; set; }
        public string Referencia { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }

        /*
        public override string ToString()
        {
            return string.Format("[rh_cat_dir_web: IdDirWeb={0}], DesDirWeb={1},  DirWeb={2}, Principal={3}, IdTipoGenDirWeb={4}, IdGenDirWeb={5}, " +
                " ClaveReferencia={6}, Referencia={7}, FechaReg={8}," +
              " UsuarioReg={9}, FechaUltMod={10}, UsuarioMod={11}, Activo={12}, Borrado={13}",
                                 IdDirWeb,  IdGenOcupacion, IdTipoGenEstadoCivil, IdGenEstadoCivil,
                                NumControl, Nombre, ApPaterno, ApMaterno, RFC, CURP, FechaNac, TipoPersona, Sexo,
                                RutaFoto, Alias, FechaReg, UsuarioReg, FechaUltMod, UsuarioMod, Activo, Borrado
                                 , IdPersona);
        }*/
    }

    public class rh_cat_domicilios
    {
        [PrimaryKey, Unique]
        public int IdDomicilio { get; set; }
        public string Domicilio { get; set; }
        public string EntreCalle1 { get; set; }
        public string EntreCalle2 { get; set; }
        public string CodigoPostal { get; set; }
        public string Coordenadas { get; set; }
        public bool Principal { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
        public string Colonia { get; set; }
        public string Referencia { get; set; }
        public string ClaveReferencia { get; set; }
        public bool TipoDomicilio { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        //FK
        [Indexed]
        public int IdTipoGenDom { get; set; }
        [Indexed]
        public int IdGenDom { get; set; }
    }

    public class rh_cat_telefonos
    {
        [PrimaryKey,Unique]
        public int IdTelefono { get; set; }
        public string CodPais { get; set; }
        public string NumTelefono { get; set; }
        public string NumExtension { get; set; }
        public bool Principal { get; set; }
        public string ClaveReferencia { get; set; }
        public string Referencia { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        //FK
        [Indexed]
        public int IdTipoGenTelefono { get; set; }
        [Indexed]
        public int IdGenTelefono { get; set; }
    }

    public class rh_cat_personas_perfiles
    {
        //FK
        [Indexed]
        public int IdPersona { get; set; }
        public int IdTipGenPerfil { get; set; }
        public int IdGenPerfil { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }

    }
    
    public class rh_cat_personas_datos_adicionales
    {
        [PrimaryKey,Unique]
        public string Etiqueta { get; set; }
        public string Valor { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        //FK
        [Indexed]
        public int IdPersona { get; set; }
        [Indexed]
        public int IdTipoGenSeccion { get; set; }
        [Indexed]
        public int IdGenSeccion { get; set; }

    }

    public class rh_cat_personas_homologadas
    {
        [PrimaryKey,Unique]
        public string RFC { get; set; }
        public int IdPersona { get; set; }
        public string NumControl { get; set; }
        public string CURP { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
    }

    public class rh_personas_perfil_estatus
    {
        [PrimaryKey, Unique]
        public int IdEstatusDet { get; set; }
        public string FechaEstatus { get; set; }
        public bool Actual { get; set; }
        public string Observaciones { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        //FK
        [Indexed]
        public int IdTipoGenPerfil {get; set;}
        [Indexed]
        public int IdGenPerfil { get; set; }
        [Indexed]
        public int IdPersona { get; set; }
        [Indexed]
        public int IdTipoEstatus { get; set; }
        [Indexed]
        public int IdEstatus { get; set; }
    }
}
