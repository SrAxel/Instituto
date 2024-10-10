﻿using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace InstitutoBack.DataContext
{
    public class InstitutoContext : DbContext
    {
        public InstitutoContext(DbContextOptions<InstitutoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string cadenaConexion = configuration.GetConnectionString("mysqlremoto");

            //optionsBuilder.UseSqlServer(cadenaConexion) ;
            optionsBuilder.UseMySql(cadenaConexion,
                                    ServerVersion.AutoDetect(cadenaConexion));
        }

        ///ESTE CÓDIGO LO DEBEN AGREGAR A LA CLASE DBCONTEXT DESPUÉS DE HABER CREADO EL MODELO MATERIA
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Datos semilla de carreras
            var tsds = new Carrera { Id = 1, Nombre = "Tecnicatura Superior en Desarrollo de Software", Sigla = "TSDS" };
            var tssi = new Carrera { Id = 2, Nombre = "Tecnicatura Superior en Soporte de Infraestructura", Sigla = "TSSITI" };
            var tsgo = new Carrera { Id = 3, Nombre = "Tecnicatura Superior en Gestion de las Organizaciones", Sigla = "TSGO" };
            var tse = new Carrera { Id = 4, Nombre = "Tecnicatura Superior en Enfermeria", Sigla = "TSE" };
            var pesca = new Carrera { Id = 5, Nombre = "Profesorado de Educación Secundaria en Ciencias de la Administración", Sigla = "PEA" };
            var pei = new Carrera { Id = 6, Nombre = "Profesorado de Educación Inicial", Sigla = "PEI" };
            var pese = new Carrera { Id = 7, Nombre = "Profesorado de Educación Secundaria en Economía", Sigla = "PEE" };
            var pet = new Carrera { Id = 8, Nombre = "Profesorado de Educación Tecnológica", Sigla = "PET" };
            var lcm = new Carrera { Id = 9, Nombre = "Licenciatura en Cooperativismo y Mutualismo", Sigla = "LCM" };
            modelBuilder.Entity<Carrera>().HasData(tsds, tssi, tsgo, tse, pesca, pei, pese, pet, lcm);
            #endregion

            #region Datos semillas de AnioCarreras
            //TECNICO SUPERIOR EN DESARROLLO DE SOFTWARE
            var ac1 = new AnioCarrera { Id = 1, CarreraId = 1, Nombre = "1er año" };
            var ac2 = new AnioCarrera { Id = 2, CarreraId = 1, Nombre = "2do año" };
            var ac3 = new AnioCarrera { Id = 3, CarreraId = 1, Nombre = "3er año" };
            //Tecnicatura Superior en Soporte de Infraestructura
            var ac4 = new AnioCarrera { Id = 4, CarreraId = 2, Nombre = "1er año" };
            var ac5 = new AnioCarrera { Id = 5, CarreraId = 2, Nombre = "2do año" };
            var ac6 = new AnioCarrera { Id = 6, CarreraId = 2, Nombre = "3er año" };
            //Tecnicatura Superior en Gestion de las Organizaciones
            var ac7 = new AnioCarrera { Id = 7, CarreraId = 3, Nombre = "1er año" };
            var ac8 = new AnioCarrera { Id = 8, CarreraId = 3, Nombre = "2do año" };
            var ac9 = new AnioCarrera { Id = 9, CarreraId = 3, Nombre = "3er año" };
            //Tecnicatura Superior en Enfermeria
            var ac10 = new AnioCarrera { Id = 10, CarreraId = 4, Nombre = "1er año" };
            var ac11 = new AnioCarrera { Id = 11, CarreraId = 4, Nombre = "2do año" };
            var ac12 = new AnioCarrera { Id = 12, CarreraId = 4, Nombre = "3er año" };
            //Profesorado de Educación Secundaria en Ciencias de la Administración
            var ac13 = new AnioCarrera { Id = 13, CarreraId = 5, Nombre = "1er año" };
            var ac14 = new AnioCarrera { Id = 14, CarreraId = 5, Nombre = "2do año" };
            var ac15 = new AnioCarrera { Id = 15, CarreraId = 5, Nombre = "3er año" };
            var ac16 = new AnioCarrera { Id = 16, CarreraId = 5, Nombre = "4to año" };
            //Profesorado de Educación Inicial
            var ac17 = new AnioCarrera { Id = 17, CarreraId = 6, Nombre = "1er año" };
            var ac18 = new AnioCarrera { Id = 18, CarreraId = 6, Nombre = "2do año" };
            var ac19 = new AnioCarrera { Id = 19, CarreraId = 6, Nombre = "3er año" };
            var ac20 = new AnioCarrera { Id = 20, CarreraId = 6, Nombre = "4to año" };
            //Profesorado de Educación Secundaria en Economía
            var ac21 = new AnioCarrera { Id = 21, CarreraId = 7, Nombre = "1er año" };
            var ac22 = new AnioCarrera { Id = 22, CarreraId = 7, Nombre = "2do año" };
            var ac23 = new AnioCarrera { Id = 23, CarreraId = 7, Nombre = "3er año" };
            var ac24 = new AnioCarrera { Id = 24, CarreraId = 7, Nombre = "4to año" };
            //Profesorado de Educación Tecnológica
            var ac25 = new AnioCarrera { Id = 25, CarreraId = 8, Nombre = "1er año" };
            var ac26 = new AnioCarrera { Id = 26, CarreraId = 8, Nombre = "2do año" };
            var ac27 = new AnioCarrera { Id = 27, CarreraId = 8, Nombre = "3er año" };
            var ac28 = new AnioCarrera { Id = 28, CarreraId = 8, Nombre = "4to año" };

            modelBuilder.Entity<AnioCarrera>().HasData(
                ac1, ac2, ac3, ac4, ac5, ac6, ac7, ac8, ac9, ac10,
                ac11, ac12, ac13, ac14, ac15, ac16, ac17, ac18,
                ac19, ac20, ac21, ac22, ac23, ac24, ac25, ac26,
                ac27, ac28);
            #endregion

            #region Datos semilla de Materias

            // PROFESORADO DE EDUCACIÓN SECUNDARIA EN ECONOMÍA
            var materiasEconomia = new[]
            {
                new Materia { Id = 1, Nombre = "Pedagogía", AnioCarreraId = 21 },
                new Materia { Id = 2, Nombre = "UCCV Sociología", AnioCarreraId = 21 },
                new Materia { Id = 3, Nombre = "Administración General", AnioCarreraId = 21 },
                new Materia { Id = 4, Nombre = "Economía I", AnioCarreraId = 21 },
                new Materia { Id = 5, Nombre = "Geografía Económica", AnioCarreraId = 21 },
                new Materia { Id = 6, Nombre = "Historia Económica", AnioCarreraId = 21 },
                new Materia { Id = 7, Nombre = "Construcción de Ciudadanía", AnioCarreraId = 21 },
                new Materia { Id = 8, Nombre = "Sistema de Información Contable I", AnioCarreraId = 21 },
                new Materia { Id = 9, Nombre = "Matemática", AnioCarreraId = 21 },
                new Materia { Id = 10, Nombre = "Práctica Docente I", AnioCarreraId = 21 },
                new Materia { Id = 11, Nombre = "Instituciones Educativas", AnioCarreraId = 22 },
                new Materia { Id = 12, Nombre = "Didáctica y Curriculum", AnioCarreraId = 22 },
                new Materia { Id = 13, Nombre = "Psicología y Educación", AnioCarreraId = 22 },
                new Materia { Id = 14, Nombre = "Economía II", AnioCarreraId = 22 },
                new Materia { Id = 15, Nombre = "Sistema de Información Contable II", AnioCarreraId = 22 },
                new Materia { Id = 16, Nombre = "Derecho I", AnioCarreraId = 22 },
                new Materia { Id = 17, Nombre = "Estadística Aplicada", AnioCarreraId = 22 },
                new Materia { Id = 18, Nombre = "Didáctica de la Economía I", AnioCarreraId = 22 },
                new Materia { Id = 19, Nombre = "Práctica Docente II", AnioCarreraId = 22 },
                new Materia { Id = 20, Nombre = "Historia y Política de la Educación Argentina", AnioCarreraId = 23 },
                new Materia { Id = 21, Nombre = "Filosofía", AnioCarreraId = 23 },
                new Materia { Id = 22, Nombre = "Metodología de la Investigación", AnioCarreraId = 23 },
                new Materia { Id = 23, Nombre = "Economía III", AnioCarreraId = 23 },
                new Materia { Id = 24, Nombre = "Finanzas Públicas", AnioCarreraId = 23 },
                new Materia { Id = 25, Nombre = "Derecho II", AnioCarreraId = 23 },
                new Materia { Id = 26, Nombre = "Sujetos de la Educación Secundaria", AnioCarreraId = 23 },
                new Materia { Id = 27, Nombre = "Práctica Docente III", AnioCarreraId = 23 },
                new Materia { Id = 28, Nombre = "Producción de los Recursos Didácticos I", AnioCarreraId = 23 },
                new Materia { Id = 29, Nombre = "Ética y Trabajo Docente", AnioCarreraId = 24 },
                new Materia { Id = 30, Nombre = "Educación Sexual Integral", AnioCarreraId = 24 },
                new Materia { Id = 31, Nombre = "UCCV Comunicación Social", AnioCarreraId = 24 },
                new Materia { Id = 32, Nombre = "Economía Social y Sostenible", AnioCarreraId = 24 },
                new Materia { Id = 33, Nombre = "Economía Argentina Latinoamericana e Internacional", AnioCarreraId = 24 },
                new Materia { Id = 34, Nombre = "Prácticas de Investigación", AnioCarreraId = 24 },
                new Materia { Id = 35, Nombre = "Práctica Docente IV (Residencia)", AnioCarreraId = 24 },
                new Materia { Id = 36, Nombre = "Producción de los Recursos Didácticos II", AnioCarreraId = 24 },
                new Materia { Id = 37, Nombre = "Unidad de Definición Institucional", AnioCarreraId = 24 }
            };

            // PROFESORADO DE EDUCACIÓN TECNOLÓGICA
            var materiasTecnologica = new[]
            {
                new Materia { Id = 38, Nombre = "Pedagogía", AnioCarreraId = 25 },
                new Materia { Id = 39, Nombre = "Movimiento y Cuerpo", AnioCarreraId = 25 },
                new Materia { Id = 40, Nombre = "Práctica Docente I: Escenarios Educativos", AnioCarreraId = 25 },
                new Materia { Id = 41, Nombre = "Introducción a la Tecnología", AnioCarreraId = 25 },
                new Materia { Id = 42, Nombre = "Historia de la Tecnología", AnioCarreraId = 25 },
                new Materia { Id = 43, Nombre = "Diseño y Producción de la Tecnología I", AnioCarreraId = 25 },
                new Materia { Id = 44, Nombre = "Matemática", AnioCarreraId = 25 },
                new Materia { Id = 45, Nombre = "Física", AnioCarreraId = 25 },
                new Materia { Id = 46, Nombre = "Psicología de la Educación", AnioCarreraId = 26 },
                new Materia { Id = 47, Nombre = "Didáctica y Curriculum", AnioCarreraId = 26 },
                new Materia { Id = 48, Nombre = "Instituciones Educativas", AnioCarreraId = 26 },
                new Materia { Id = 49, Nombre = "Práctica Docente II: La Institución Escolar", AnioCarreraId = 26 },
                new Materia { Id = 50, Nombre = "Sujetos de la Educación I", AnioCarreraId = 26 },
                new Materia { Id = 51, Nombre = "Tics para la Enseñanza", AnioCarreraId = 26 },
                new Materia { Id = 52, Nombre = "Procesos Productivos", AnioCarreraId = 26 },
                new Materia { Id = 53, Nombre = "Diseño y Producción Tecnológica II", AnioCarreraId = 26 },
                new Materia { Id = 54, Nombre = "Didáctica Específica I", AnioCarreraId = 26 },
                new Materia { Id = 55, Nombre = "Filosofía y Educación", AnioCarreraId = 27 },
                new Materia { Id = 56, Nombre = "Historia Social de la Educación", AnioCarreraId = 27 },
                new Materia { Id = 57, Nombre = "Metodología de la Investigación", AnioCarreraId = 27 },
                new Materia { Id = 58, Nombre = "Práctica Docente III: La Clase", AnioCarreraId = 27 },
                new Materia { Id = 59, Nombre = "Sujetos de la Educación II", AnioCarreraId = 27 },
                new Materia { Id = 60, Nombre = "Materiales", AnioCarreraId = 27 },
                new Materia { Id = 61, Nombre = "Química", AnioCarreraId = 27 },
                new Materia { Id = 62, Nombre = "Procesos de Control", AnioCarreraId = 27 },
                new Materia { Id = 63, Nombre = "Tecnologías Regionales", AnioCarreraId = 27 },
                new Materia { Id = 64, Nombre = "Diseño y Producción Tecnológica III", AnioCarreraId = 27 },
                new Materia { Id = 65, Nombre = "Didáctica Específica II", AnioCarreraId = 27 },
                new Materia { Id = 66, Nombre = "Ética y Trabajo Docente", AnioCarreraId = 28 },
                new Materia { Id = 67, Nombre = "Educación Sexual Integral", AnioCarreraId = 28 },
                new Materia { Id = 68, Nombre = "Unidades de Definición Institucional I", AnioCarreraId = 28 },
                new Materia { Id = 69, Nombre = "Unidades de Definición Institucional II", AnioCarreraId = 28 },
                new Materia { Id = 70, Nombre = "Prácticas de Investigación", AnioCarreraId = 28 },
                new Materia { Id = 71, Nombre = "Práctica Docente IV: El Rol Docente y su Práctica", AnioCarreraId = 28 },
                new Materia { Id = 72, Nombre = "Biotecnología", AnioCarreraId = 28 },
                new Materia { Id = 73, Nombre = "Procesos de Comunicación", AnioCarreraId = 28 },
                new Materia { Id = 74, Nombre = "Problemáticas Sociotécnicas", AnioCarreraId = 28 },
                new Materia { Id = 75, Nombre = "Diseño y Producción Tecnológica IV", AnioCarreraId = 28 },
                new Materia { Id = 76, Nombre = "Taller de Producción Didáctica", AnioCarreraId = 28 }
            };

            // TÉCNICO SUPERIOR EN DESARROLLO DE SOFTWARE
            var materiasSoftware = new[]
            {
                new Materia { Id = 77, Nombre = "Comunicación (1° cuat.)", AnioCarreraId = 1 },
                new Materia { Id = 78, Nombre = "Unidad de definición Institucional (2° cuat.)", AnioCarreraId = 1 },
                new Materia { Id = 79, Nombre = "Matemática", AnioCarreraId = 1 },
                new Materia { Id = 80, Nombre = "Inglés Técnico I", AnioCarreraId = 1 },
                new Materia { Id = 81, Nombre = "Administración", AnioCarreraId = 1 },
                new Materia { Id = 82, Nombre = "Tecnología de la Información", AnioCarreraId = 1 },
                new Materia { Id = 83, Nombre = "Lógica y Estructura de Datos", AnioCarreraId = 1 },
                new Materia { Id = 84, Nombre = "Ingeniería de Software I", AnioCarreraId = 1 },
                new Materia { Id = 85, Nombre = "Sistemas Operativos", AnioCarreraId = 1 },
                new Materia { Id = 86, Nombre = "Problemáticas Socio Contemporáneas (1° cuat.)", AnioCarreraId = 2 },
                new Materia { Id = 87, Nombre = "Unidad de definición Institucional (2° cuat.)", AnioCarreraId = 2 },
                new Materia { Id = 88, Nombre = "Inglés Técnico II", AnioCarreraId = 2 },
                new Materia { Id = 89, Nombre = "Innovación y Desarrollo Emprendedor", AnioCarreraId = 2 },
                new Materia { Id = 90, Nombre = "Estadística", AnioCarreraId = 2 },
                new Materia { Id = 91, Nombre = "Programación I", AnioCarreraId = 2 },
                new Materia { Id = 92, Nombre = "Ingeniería de Software II", AnioCarreraId = 2 },
                new Materia { Id = 93, Nombre = "Base de Datos I", AnioCarreraId = 2 },
                new Materia { Id = 94, Nombre = "Práctica Profesionalizante I", AnioCarreraId = 2 },
                new Materia { Id = 95, Nombre = "Ética y Responsabilidad Social", AnioCarreraId = 3 },
                new Materia { Id = 96, Nombre = "Derecho y Legislación Laboral", AnioCarreraId = 3 },
                new Materia { Id = 97, Nombre = "Redes y Comunicación", AnioCarreraId = 3 },
                new Materia { Id = 98, Nombre = "Programación II", AnioCarreraId = 3 },
                new Materia { Id = 99, Nombre = "Gestión de Proyectos de Software", AnioCarreraId = 3 },
                new Materia { Id = 100, Nombre = "Base de Datos II", AnioCarreraId = 3 },
                new Materia { Id = 101, Nombre = "Práctica Profesionalizante II", AnioCarreraId = 3 }
            };

            // TÉCNICO SUPERIOR EN ENFERMERÍA
            var materiasEnfermeria = new[]
            {
                new Materia { Id = 102, Nombre = "Comunicación", AnioCarreraId = 10 },
                new Materia { Id = 103, Nombre = "Unidad de Definición Institucional I", AnioCarreraId = 10 },
                new Materia { Id = 104, Nombre = "Salud Pública", AnioCarreraId = 10 },
                new Materia { Id = 105, Nombre = "Biología Humana I", AnioCarreraId = 10 },
                new Materia { Id = 106, Nombre = "Sujeto, Cultura y Sociedad", AnioCarreraId = 10 },
                new Materia { Id = 107, Nombre = "Fundamentos del Cuidado en Enfermería", AnioCarreraId = 10 },
                new Materia { Id = 108, Nombre = "Cuidados de Enfermería en la Comunidad y en la Familia", AnioCarreraId = 10 },
                new Materia { Id = 109, Nombre = "Práctica Profesionalizante I", AnioCarreraId = 10 },
                new Materia { Id = 110, Nombre = "Problemáticas Socio Contemporáneas", AnioCarreraId = 11 },
                new Materia { Id = 111, Nombre = "Unidad de Definición Institucional II", AnioCarreraId = 11 },
                new Materia { Id = 112, Nombre = "Informática en Salud", AnioCarreraId = 11 },
                new Materia { Id = 113, Nombre = "Sujeto, Cultura y Sociedad II", AnioCarreraId = 11 },
                new Materia { Id = 114, Nombre = "Biología Humana II", AnioCarreraId = 11 },
                new Materia { Id = 115, Nombre = "Bioseguridad y Medio Ambiente en el Trabajo", AnioCarreraId = 11 },
                new Materia { Id = 116, Nombre = "Farmacología en Enfermería", AnioCarreraId = 11 },
                new Materia { Id = 117, Nombre = "Cuidados de Enfermería a los Adultos y Adultos Mayores", AnioCarreraId = 11 },
                new Materia { Id = 118, Nombre = "Práctica Profesionalizante II", AnioCarreraId = 11 },
                new Materia { Id = 119, Nombre = "Ética y Responsabilidad Social", AnioCarreraId = 12 },
                new Materia { Id = 120, Nombre = "Derecho y Legislación Laboral", AnioCarreraId = 12 },
                new Materia { Id = 121, Nombre = "Inglés Técnico", AnioCarreraId = 12 },
                new Materia { Id = 122, Nombre = "Organización y Gestión en Instituciones de Salud", AnioCarreraId = 12 },
                new Materia { Id = 123, Nombre = "Investigación en Enfermería", AnioCarreraId = 12 },
                new Materia { Id = 124, Nombre = "Cuidados de Enfermería en Salud Mental", AnioCarreraId = 12 },
                new Materia { Id = 125, Nombre = "Cuidados de Enfermería al Niño y al Adolescente", AnioCarreraId = 12 },
                new Materia { Id = 126, Nombre = "Práctica Profesionalizante III", AnioCarreraId = 12 }
            };

            // TÉCNICO SUPERIOR EN GESTIÓN DE LAS ORGANIZACIONES
            var materiasOrganizaciones = new[]
            {
                new Materia { Id = 127, Nombre = "Comunicación (1º cuatr.)", AnioCarreraId = 7 },
                new Materia { Id = 128, Nombre = "Unidad de Definición Institucional (2º cuatr.)", AnioCarreraId = 7 },
                new Materia { Id = 129, Nombre = "Economía", AnioCarreraId = 7 },
                new Materia { Id = 130, Nombre = "Matemática y Estadística", AnioCarreraId = 7 },
                new Materia { Id = 131, Nombre = "Contabilidad", AnioCarreraId = 7 },
                new Materia { Id = 132, Nombre = "Informática", AnioCarreraId = 7 },
                new Materia { Id = 133, Nombre = "Administración", AnioCarreraId = 7 },
                new Materia { Id = 134, Nombre = "Gestión de la Producción", AnioCarreraId = 7 },
                new Materia { Id = 135, Nombre = "Gestión del Talento Humano", AnioCarreraId = 7 },
                new Materia { Id = 136, Nombre = "Problemáticas Contemporáneas (1º cuatr.)", AnioCarreraId = 8 },
                new Materia { Id = 137, Nombre = "Unidad de Definición Institucional (2º cuatr.)", AnioCarreraId = 8 },
                new Materia { Id = 138, Nombre = "Innovación y Desarrollo Emprendedor", AnioCarreraId = 8 },
                new Materia { Id = 139, Nombre = "Inglés Técnico", AnioCarreraId = 8 },
                new Materia { Id = 140, Nombre = "Legislación Comercial y Tributaria", AnioCarreraId = 8 },
                new Materia { Id = 141, Nombre = "Gestión de Comercialización e Investigación Comercial", AnioCarreraId = 8 },
                new Materia { Id = 142, Nombre = "Gestión de Costos", AnioCarreraId = 8 },
                new Materia { Id = 143, Nombre = "Gestión Contable", AnioCarreraId = 8 },
                new Materia { Id = 144, Nombre = "Práctica Profesionalizante I", AnioCarreraId = 8 },
                new Materia { Id = 145, Nombre = "Gestión de Seguridad, Salud Ocupacional y Medio Ambiente", AnioCarreraId = 9 },
                new Materia { Id = 146, Nombre = "Ética y Responsabilidad Social", AnioCarreraId = 9 },
                new Materia { Id = 147, Nombre = "Legislación Laboral", AnioCarreraId = 9 },
                new Materia { Id = 148, Nombre = "Estrategia Empresarial", AnioCarreraId = 9 },
                new Materia { Id = 149, Nombre = "Sistema de Información para la Gestión de las Organizaciones", AnioCarreraId = 9 },
                new Materia { Id = 150, Nombre = "Gestión Financiera", AnioCarreraId = 9 },
                new Materia { Id = 151, Nombre = "Evaluación y Administración de Proyectos de Inversión", AnioCarreraId = 9 },
                new Materia { Id = 152, Nombre = "Control de Gestión", AnioCarreraId = 9 },
                new Materia { Id = 153, Nombre = "Prácticas Profesionalizantes II", AnioCarreraId = 9 }
            };

            // TÉCNICO SUPERIOR EN SOPORTE DE INFRAESTRUCTURA DE TECNOLOGÍA DE LA INFORMACIÓN
            var materiasInfraestructura = new[]
            {
                new Materia { Id = 154, Nombre = "Comunicación (1° cuat.)", AnioCarreraId = 4 },
                new Materia { Id = 155, Nombre = "Unidad de definición Institucional (2° cuat.)", AnioCarreraId = 4 },
                new Materia { Id = 156, Nombre = "Matemática", AnioCarreraId = 4 },
                new Materia { Id = 157, Nombre = "Física Aplicada a las Tecnologías de la Información", AnioCarreraId = 4 },
                new Materia { Id = 158, Nombre = "Administración", AnioCarreraId = 4 },
                new Materia { Id = 159, Nombre = "Inglés Técnico", AnioCarreraId = 4 },
                new Materia { Id = 160, Nombre = "Arquitectura de las Computadoras", AnioCarreraId = 4 },
                new Materia { Id = 161, Nombre = "Lógica y Programación", AnioCarreraId = 4 },
                new Materia { Id = 162, Nombre = "Infraestructura de Redes I", AnioCarreraId = 4 },
                new Materia { Id = 163, Nombre = "Problemáticas Socio Contemporáneas (1° cuat.)", AnioCarreraId = 5 },
                new Materia { Id = 164, Nombre = "Unidad de definición Institucional (2° cuat.)", AnioCarreraId = 5 },
                new Materia { Id = 165, Nombre = "Innovación y Desarrollo Emprendedor", AnioCarreraId = 5 },
                new Materia { Id = 166, Nombre = "Estadística", AnioCarreraId = 5 },
                new Materia { Id = 167, Nombre = "Sistemas Operativos", AnioCarreraId = 5 },
                new Materia { Id = 168, Nombre = "Algoritmos y Estructuras de Datos", AnioCarreraId = 5 },
                new Materia { Id = 169, Nombre = "Base de Datos", AnioCarreraId = 5 },
                new Materia { Id = 170, Nombre = "Infraestructura de Redes II", AnioCarreraId = 5 },
                new Materia { Id = 171, Nombre = "Práctica Profesionalizante I", AnioCarreraId = 5 },
                new Materia { Id = 172, Nombre = "Ética y Responsabilidad Social", AnioCarreraId = 6 },
                new Materia { Id = 173, Nombre = "Derecho y Legislación Laboral", AnioCarreraId = 6 },
                new Materia { Id = 174, Nombre = "Administración de Base de Datos", AnioCarreraId = 6 },
                new Materia { Id = 175, Nombre = "Integridad y Migración de Datos", AnioCarreraId = 6 },
                new Materia { Id = 176, Nombre = "Seguridad de los Sistemas", AnioCarreraId = 6 },
                new Materia { Id = 177, Nombre = "Administración de Sistemas Operativos y Redes", AnioCarreraId = 6 },
                new Materia { Id = 178, Nombre = "Práctica Profesionalizante II", AnioCarreraId = 6 }

            };

            modelBuilder.Entity<Materia>().HasData(materiasEconomia);
            modelBuilder.Entity<Materia>().HasData(materiasTecnologica);
            modelBuilder.Entity<Materia>().HasData(materiasSoftware);
            modelBuilder.Entity<Materia>().HasData(materiasEnfermeria);
            modelBuilder.Entity<Materia>().HasData(materiasOrganizaciones);
            modelBuilder.Entity<Materia>().HasData(materiasInfraestructura);

            #region Datos semilla de Materias - Profesorado de Educación Inicial

            // Primer Año
            var m1 = new Materia { Id = 179, AnioCarreraId = 17, Nombre = "Psicología y Educación" };
            var m2 = new Materia { Id = 180, AnioCarreraId = 17, Nombre = "Pedagogía" };
            var m3 = new Materia { Id = 181, AnioCarreraId = 17, Nombre = "Sociología de la Educación" };
            var m4 = new Materia { Id = 182, AnioCarreraId = 17, Nombre = "Historia Argentina y Latinoamericana (1º cuatr.)" };
            var m5 = new Materia { Id = 183, AnioCarreraId = 17, Nombre = "Movimiento y Cuerpo I" };
            var m6 = new Materia { Id = 184, AnioCarreraId = 17, Nombre = "Taller de Práctica I" };
            var m7 = new Materia { Id = 185, AnioCarreraId = 17, Nombre = "Problemáticas Contemporáneas de la Educación Inicial I" };
            var m8 = new Materia { Id = 186, AnioCarreraId = 17, Nombre = "Comunicación y Expresión Oral y Escrita" };
            var m9 = new Materia { Id = 187, AnioCarreraId = 17, Nombre = "Resolución de Problemas y Creatividad (1º cuatr.)" };
            var m10 = new Materia { Id = 188, AnioCarreraId = 17, Nombre = "Ambiente y Sociedad (2º cuatr.)" };
            var m11 = new Materia { Id = 189, AnioCarreraId = 17, Nombre = "Área Estético-Expresiva I" };
            var m12 = new Materia { Id = 190, AnioCarreraId = 17, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m13 = new Materia { Id = 191, AnioCarreraId = 17, Nombre = "Producción Pedagógica" };

            // Segundo Año
            var m14 = new Materia { Id = 192, AnioCarreraId = 18, Nombre = "Didáctica General" };
            var m15 = new Materia { Id = 193, AnioCarreraId = 18, Nombre = "Filosofía de la Educación (1º cuatr.)" };
            var m16 = new Materia { Id = 194, AnioCarreraId = 18, Nombre = "Conocimiento y Educación (2º cuatr.)" };
            var m17 = new Materia { Id = 195, AnioCarreraId = 18, Nombre = "Movimiento y Cuerpo II" };
            var m18 = new Materia { Id = 196, AnioCarreraId = 18, Nombre = "Taller de Práctica II: Seminario de lo Grupal y los Grupos de Aprendizaje" };
            var m19 = new Materia { Id = 197, AnioCarreraId = 18, Nombre = "Sujeto de la Educación Inicial" };
            var m20 = new Materia { Id = 198, AnioCarreraId = 18, Nombre = "Didáctica de Educación Inicial I" };
            var m21 = new Materia { Id = 199, AnioCarreraId = 18, Nombre = "Matemática y su Didáctica I" };
            var m22 = new Materia { Id = 200, AnioCarreraId = 18, Nombre = "Literatura y su Didáctica" };
            var m23 = new Materia { Id = 201, AnioCarreraId = 18, Nombre = "Ciencias Naturales y su Didáctica" };
            var m24 = new Materia { Id = 202, AnioCarreraId = 18, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m25 = new Materia { Id = 203, AnioCarreraId = 18, Nombre = "Producción Pedagógica" };

            // Tercer Año
            var m26 = new Materia { Id = 204, AnioCarreraId = 19, Nombre = "Tecnologías de la Información y de la Comunicación" };
            var m27 = new Materia { Id = 205, AnioCarreraId = 19, Nombre = "Historia Social de la Educación y Política Educativa Argentina" };
            var m28 = new Materia { Id = 206, AnioCarreraId = 19, Nombre = "Trayecto de Práctica III: Seminario de Instituciones Educativas" };
            var m29 = new Materia { Id = 207, AnioCarreraId = 19, Nombre = "Matemática y su Didáctica II" };
            var m30 = new Materia { Id = 208, AnioCarreraId = 19, Nombre = "Lengua y su Didáctica (1º cuatr.)" };
            var m31 = new Materia { Id = 209, AnioCarreraId = 19, Nombre = "Alfabetización Inicial (2º cuatr.)" };
            var m32 = new Materia { Id = 210, AnioCarreraId = 19, Nombre = "Ciencias Sociales y su Didáctica" };
            var m33 = new Materia { Id = 211, AnioCarreraId = 19, Nombre = "Área Estético-Expresiva II" };
            var m34 = new Materia { Id = 212, AnioCarreraId = 19, Nombre = "Problemáticas Contemporáneas de la Educación Inicial II (1º cuatr.)" };
            var m35 = new Materia { Id = 213, AnioCarreraId = 19, Nombre = "Didáctica de la Educación Inicial II (2º cuatr.)" };
            var m36 = new Materia { Id = 214, AnioCarreraId = 19, Nombre = "Espacios de Definición Institucional (1º cuatr.)" };
            var m37 = new Materia { Id = 215, AnioCarreraId = 19, Nombre = "Espacios de Definición Institucional (2º cuatr.)" };
            var m38 = new Materia { Id = 216, AnioCarreraId = 19, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m39 = new Materia { Id = 217, AnioCarreraId = 19, Nombre = "Producción Pedagógica" };

            // Cuarto Año
            var m40 = new Materia { Id = 218, AnioCarreraId = 20, Nombre = "Ética, Trabajo Docente, Derechos Humanos y Ciudadanos" };
            var m41 = new Materia { Id = 219, AnioCarreraId = 20, Nombre = "Taller de Práctica IV" };
            var m42 = new Materia { Id = 220, AnioCarreraId = 20, Nombre = "Ateneo: (Matemática- Ambiente y Sociedad (Ciencias Naturales- Ciencias Sociales) Lengua y Literatura- Formación Ética y Ciudadana)" };
            var m43 = new Materia { Id = 221, AnioCarreraId = 20, Nombre = "Sexualidad Humana y Educación (1º cuatr.)" };
            var m44 = new Materia { Id = 222, AnioCarreraId = 20, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m45 = new Materia { Id = 223, AnioCarreraId = 20, Nombre = "Producción Pedagógica" };

            modelBuilder.Entity<Materia>().HasData(
                m1, m2, m3, m4, m5, m6, m7, m8, m9, m10,
                m11, m12, m13, m14, m15, m16, m17, m18,
                m19, m20, m21, m22, m23, m24, m25, m26,
                m27, m28, m29, m30, m31, m32, m33, m34,
                m35, m36, m37, m38, m39, m40, m41, m42,
                m43, m44, m45);

            #endregion

            #region Datos semillas de Materias para Profesorado de Educación Secundaria en Ciencias de la Administración

            // Primer Año
            var mm1 = new Materia { Id = 224, AnioCarreraId = 13, Nombre = "Pedagogía" };
            var mm2 = new Materia { Id = 225, AnioCarreraId = 13, Nombre = "UCCV Sociología" };
            var mm3 = new Materia { Id = 226, AnioCarreraId = 13, Nombre = "Administración General" };
            var mm4 = new Materia { Id = 227, AnioCarreraId = 13, Nombre = "Administración I" };
            var mm5 = new Materia { Id = 228, AnioCarreraId = 13, Nombre = "Sistema de Información Contable I" };
            var mm6 = new Materia { Id = 229, AnioCarreraId = 13, Nombre = "Construcción de Ciudadanía" };
            var mm7 = new Materia { Id = 230, AnioCarreraId = 13, Nombre = "Historia Económica" };
            var mm8 = new Materia { Id = 231, AnioCarreraId = 13, Nombre = "Matemática" };
            var mm9 = new Materia { Id = 232, AnioCarreraId = 13, Nombre = "Práctica Docente I" };

            // Segundo Año
            var mm10 = new Materia { Id = 233, AnioCarreraId = 14, Nombre = "Instituciones Educativas" };
            var mm11 = new Materia { Id = 234, AnioCarreraId = 14, Nombre = "Didáctica y Curriculum" };
            var mm12 = new Materia { Id = 235, AnioCarreraId = 14, Nombre = "Psicología y Educación" };
            var mm13 = new Materia { Id = 236, AnioCarreraId = 14, Nombre = "Administración II" };
            var mm14 = new Materia { Id = 237, AnioCarreraId = 14, Nombre = "Sistema de Información Contable II" };
            var mm15 = new Materia { Id = 238, AnioCarreraId = 14, Nombre = "Derecho I" };
            var mm16 = new Materia { Id = 239, AnioCarreraId = 14, Nombre = "Economía" };
            var mm17 = new Materia { Id = 240, AnioCarreraId = 14, Nombre = "Estadística Aplicada" };
            var mm18 = new Materia { Id = 241, AnioCarreraId = 14, Nombre = "Didáctica de la Administración I" };
            var mm19 = new Materia { Id = 242, AnioCarreraId = 14, Nombre = "Práctica Docencia II" };

            // Tercer Año
            var mm20 = new Materia { Id = 243, AnioCarreraId = 15, Nombre = "Historia y Política de la Educación Argentina" };
            var mm21 = new Materia { Id = 244, AnioCarreraId = 15, Nombre = "Filosofía" };
            var mm22 = new Materia { Id = 245, AnioCarreraId = 15, Nombre = "Metodología de la Investigación" };
            var mm23 = new Materia { Id = 246, AnioCarreraId = 15, Nombre = "Administración III" };
            var mm24 = new Materia { Id = 247, AnioCarreraId = 15, Nombre = "Sistema de Información Contable III" };
            var mm25 = new Materia { Id = 248, AnioCarreraId = 15, Nombre = "Práctica Impositiva y Laboral" };
            var mm26 = new Materia { Id = 249, AnioCarreraId = 15, Nombre = "Derecho II" };
            var mm27 = new Materia { Id = 250, AnioCarreraId = 15, Nombre = "Didáctica de la Administración II" };
            var mm28 = new Materia { Id = 251, AnioCarreraId = 15, Nombre = "Sujetos de la Educación Secundaria" };
            var mm29 = new Materia { Id = 252, AnioCarreraId = 15, Nombre = "Práctica Docente III" };
            var mm30 = new Materia { Id = 253, AnioCarreraId = 15, Nombre = "Producción de los Recursos Didácticos I" };

            // Cuarto Año
            var mm31 = new Materia { Id = 254, AnioCarreraId = 16, Nombre = "Ética y Trabajo Docente" };
            var mm32 = new Materia { Id = 255, AnioCarreraId = 16, Nombre = "Educación Sexual Integral" };
            var mm33 = new Materia { Id = 256, AnioCarreraId = 16, Nombre = "UCCV Comunicación Social" };
            var mm34 = new Materia { Id = 257, AnioCarreraId = 16, Nombre = "Administración IV" };
            var mm35 = new Materia { Id = 258, AnioCarreraId = 16, Nombre = "Gestión Organizacional" };
            var mm36 = new Materia { Id = 259, AnioCarreraId = 16, Nombre = "Matemática Financiera" };
            var mm37 = new Materia { Id = 260, AnioCarreraId = 16, Nombre = "Prácticas de Investigación" };
            var mm38 = new Materia { Id = 261, AnioCarreraId = 16, Nombre = "Práctica Docente IV (Residencia)" };
            var mm39 = new Materia { Id = 262, AnioCarreraId = 16, Nombre = "Producción de los Recursos Didácticos II" };
            var mm40 = new Materia { Id = 263, AnioCarreraId = 16, Nombre = "Unidad de Definición Institucional" };

            modelBuilder.Entity<Materia>().HasData(
                mm1, mm2, mm3, mm4, mm5, mm6, mm7, mm8, mm9, mm10,
                mm11, mm12, mm13, mm14, mm15, mm16, mm17, mm18, mm19, mm20,
                mm21, mm22, mm23, mm24, mm25, mm26, mm27, mm28, mm29, mm30,
                mm31, mm32, mm33, mm34, mm35, mm36, mm37, mm38, mm39, mm40
            );
            int initialId = 264;
            modelBuilder.Entity<Materia>().HasData(
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 1 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 2 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 3 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 4 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 5 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 6 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 7 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 8 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 9 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 10 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 11 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 12 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 13 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 14 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 15 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 16 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 17 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 18 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 19 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 20 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 21 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 22 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 23 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 24 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 25 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 26 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 27 },
                new Materia { Id = initialId++, Nombre = "Recreo", AnioCarreraId = 28 }
                );
            #endregion
            #endregion

            #region datos semillas alumnos
            var ale = new Alumno { Id = 1, ApellidoNombre = "Rubén Alejandro Ramirez", Email = "aleramirezsj@gmail.com", Direccion = "Bv Roque Saenz Peña 2942", Telefono = "15447106" };

            modelBuilder.Entity<Alumno>().HasData(ale);
            #endregion

            #region definición de filtros de eliminación
            // (este código no lo habilitamos todavía porque es cuando agregamos un campo Eliminado a las tablas y modificamos los
            // ApiControllers para que al mandar a eliminar solo cambien este campo y lo pongan en verdadero, esta configuración de
            // eliminación hace que el sistema ignore los registros que tengan el eliminado en verdadero, así que hace que en
            // apariencia y funcionalidad esté "eliminado", pero van a seguir estando ahí para que podamos observar las eliminaciones que hubo)
            modelBuilder.Entity<CicloLectivo>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<AnioCarrera>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Carrera>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Materia>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Alumno>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Inscripcion>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<DetalleInscripcion>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<MesaExamen>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<DetalleMesaExamen>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<InscriptoCarrera>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Docente>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<TurnoExamen>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Usuario>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<DetalleHorario>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Hora>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Horario>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<IntegranteHorario>().HasQueryFilter(m => !m.Eliminado);
            #endregion

            #region datos semillas turnosExamenes
            var turno = new TurnoExamen { Id = 1, Nombre = "Julio/Agosto 2024" };

            modelBuilder.Entity<TurnoExamen>().HasData(turno);
            #endregion
            #region datos semillas CiclosLectivos
            var ciclo = new CicloLectivo { Id = 1, Nombre = "2024" };

            modelBuilder.Entity<CicloLectivo>().HasData(ciclo);
            #endregion
            #region datos semillas Inscripcion
            var inscripcion = new Inscripcion { Id = 1, AlumnoId = 1, CarreraId = 1, Fecha = DateTime.Now, CicloLectivoId = 1 };

            modelBuilder.Entity<Inscripcion>().HasData(inscripcion);
            #endregion
            #region datos semillas DetalleInscripcion
            var detalleInscripcion = new DetalleInscripcion { Id = 1, InscripcionId = 1, MateriaId = 1, ModalidadCursado = ModalidadCursadoEnum.Presencial };

            modelBuilder.Entity<DetalleInscripcion>().HasData(detalleInscripcion);
            #endregion
            #region datos semillas Docentes
            modelBuilder.Entity<Docente>().HasData(
    new Docente { Id = 1, Nombre = "Adamo, G." },
    new Docente { Id = 2, Nombre = "Aimar, M.A." },
    new Docente { Id = 3, Nombre = "Albaristo, Stef." },
    new Docente { Id = 4, Nombre = "Alesso, A." },
    new Docente { Id = 5, Nombre = "Alesso, M." },
    new Docente { Id = 6, Nombre = "Arnolfo, P." },
    new Docente { Id = 7, Nombre = "Bazán, D." },
    new Docente { Id = 8, Nombre = "Blanche, C." },
    new Docente { Id = 9, Nombre = "Bogni, J." },
    new Docente { Id = 10, Nombre = "Brondino, D." },
    new Docente { Id = 11, Nombre = "Brussa, G." },
    new Docente { Id = 12, Nombre = "Buceta, MB." },
    new Docente { Id = 13, Nombre = "Bueno, M.F." },
    new Docente { Id = 14, Nombre = "Cainero, G." },
    new Docente { Id = 15, Nombre = "Calvo, M." },
    new Docente { Id = 16, Nombre = "Cavallini, J." },
    new Docente { Id = 17, Nombre = "Chauderón, L." },
    new Docente { Id = 18, Nombre = "Chelini, V." },
    new Docente { Id = 19, Nombre = "Corradi, R." },
    new Docente { Id = 20, Nombre = "Dalesio, C." },
    new Docente { Id = 21, Nombre = "Degiorgio, O." },
    new Docente { Id = 22, Nombre = "Della Rosa, M." },
    new Docente { Id = 23, Nombre = "Dellaferrera, C." },
    new Docente { Id = 24, Nombre = "Doglioli, M." },
    new Docente { Id = 25, Nombre = "Duran, C." },
    new Docente { Id = 26, Nombre = "Epes, B." },
    new Docente { Id = 27, Nombre = "Espru, F." },
    new Docente { Id = 28, Nombre = "Ferreyra, M." },
    new Docente { Id = 29, Nombre = "Ferrero, M." },
    new Docente { Id = 30, Nombre = "Ferr, N." },
    new Docente { Id = 31, Nombre = "Gaido, J.P." },
    new Docente { Id = 32, Nombre = "Galmes, M." },
    new Docente { Id = 33, Nombre = "Genero, A." },
    new Docente { Id = 34, Nombre = "Gongora, L." },
    new Docente { Id = 35, Nombre = "Gomez, V." },
    new Docente { Id = 36, Nombre = "Gretter, M.C." },
    new Docente { Id = 37, Nombre = "Grosso, S." },
    new Docente { Id = 38, Nombre = "Imhof, R." },
    new Docente { Id = 39, Nombre = "Imperiale, M." },
    new Docente { Id = 40, Nombre = "Lodi, L." },
    new Docente { Id = 41, Nombre = "Lovino, F." },
    new Docente { Id = 42, Nombre = "Mancilla, J." },
    new Docente { Id = 43, Nombre = "Manattini, S." },
    new Docente { Id = 44, Nombre = "Marenoni, A." },
    new Docente { Id = 45, Nombre = "Martínez, G." },
    new Docente { Id = 46, Nombre = "Mendoza, M." },
    new Docente { Id = 47, Nombre = "Miñoz, A." },
    new Docente { Id = 48, Nombre = "Molina, T." },
    new Docente { Id = 49, Nombre = "Monzón, M.I." },
    new Docente { Id = 50, Nombre = "Nasimbera, R." },
    new Docente { Id = 51, Nombre = "Ortiz, L." },
    new Docente { Id = 52, Nombre = "Paredes, M." },
    new Docente { Id = 53, Nombre = "Pedrazzoli, F." },
    new Docente { Id = 54, Nombre = "Pereyra, S." },
    new Docente { Id = 55, Nombre = "Peressin, S." },
    new Docente { Id = 56, Nombre = "Prida, C." },
    new Docente { Id = 57, Nombre = "Puccio, D." },
    new Docente { Id = 58, Nombre = "Quaglia, E." },
    new Docente { Id = 59, Nombre = "Ramirez, R.A." },
    new Docente { Id = 60, Nombre = "Renteria, D." },
    new Docente { Id = 61, Nombre = "Rodriguez Quain, J." },
    new Docente { Id = 62, Nombre = "Rosso, E." },
    new Docente { Id = 63, Nombre = "Sanchez, R." },
    new Docente { Id = 64, Nombre = "Sandoval, P." },
    new Docente { Id = 65, Nombre = "Sancho, I." },
    new Docente { Id = 66, Nombre = "Sara, J." },
    new Docente { Id = 67, Nombre = "Strada, J." },
    new Docente { Id = 68, Nombre = "Tovar, C." },
    new Docente { Id = 69, Nombre = "Tregnaghi, C." },
    new Docente { Id = 70, Nombre = "Tschopp, M.R." },
    new Docente { Id = 71, Nombre = "Verzzali, A." },
    new Docente { Id = 72, Nombre = "Vigniatti, E." },
    new Docente { Id = 73, Nombre = "Villa, M.F." },
    new Docente { Id = 74, Nombre = "Ruiz, A." },
    new Docente { Id = 75, Nombre = "Sager, L." }
        );
            #endregion
            #region datos semillas Mesas de examenes
            var mesasExamen = new List<MesaExamen>();
            var detallesMesaExamen = new List<DetalleMesaExamen>();
            int mesaId = 1;
            int detalleId = 1;

            void AgregarMesa(DateTime fecha, int materiaId, string horario)
            {
                mesasExamen.Add(new MesaExamen
                {
                    Id = mesaId++,
                    Llamado1 = fecha,
                    Llamado2 = fecha.AddDays(14),
                    MateriaId = materiaId,
                    Horario = horario,
                    TurnoExamenId = 1 // ID del turno "Jul/Ago 2024"
                });
            }

            void AgregarDetalleMesa(int mesaId, int presidenteId, int vocal1Id, int vocal2Id, int suplenteId)
            {
                detallesMesaExamen.Add(new DetalleMesaExamen { Id = detalleId++, MesaExamenId = mesaId, DocenteId = presidenteId, TipoIntegrante = TipoIntegranteEnum.Presidente });
                detallesMesaExamen.Add(new DetalleMesaExamen { Id = detalleId++, MesaExamenId = mesaId, DocenteId = vocal1Id, TipoIntegrante = TipoIntegranteEnum.Vocal1 });
                detallesMesaExamen.Add(new DetalleMesaExamen { Id = detalleId++, MesaExamenId = mesaId, DocenteId = vocal2Id, TipoIntegrante = TipoIntegranteEnum.Vocal2 });
                detallesMesaExamen.Add(new DetalleMesaExamen { Id = detalleId++, MesaExamenId = mesaId, DocenteId = suplenteId, TipoIntegrante = TipoIntegranteEnum.Suplente });
            }

            // Profesorado de Educación Tecnológica
            AgregarMesa(new DateTime(2024, 7, 25), 41, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 6, 66, 56, 16);

            AgregarMesa(new DateTime(2024, 7, 29), 38, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 71, 43, 39, 66);

            AgregarMesa(new DateTime(2024, 7, 30), 41, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 66, 45, 39, 28);

            AgregarMesa(new DateTime(2024, 7, 31), 45, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 38, 53, 6, 23);

            AgregarMesa(new DateTime(2024, 8, 1), 44, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 11, 58, 54, 56);

            // Segundo año
            AgregarMesa(new DateTime(2024, 7, 23), 52, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 47, 16, 73, 16);

            AgregarMesa(new DateTime(2024, 7, 30), 46, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 39, 66, 45, 28);

            AgregarMesa(new DateTime(2024, 7, 31), 47, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 28, 73, 39, 23);

            AgregarMesa(new DateTime(2024, 8, 1), 48, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 73, 16, 6, 56);

            // Tercer año
            AgregarMesa(new DateTime(2024, 7, 23), 62, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 16, 47, 73, 16);

            AgregarMesa(new DateTime(2024, 7, 25), 60, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 56, 6, 66, 53);

            AgregarMesa(new DateTime(2024, 7, 29), 57, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 43, 71, 39, 66);

            AgregarMesa(new DateTime(2024, 7, 31), 59, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 73, 28, 39, 23);

            AgregarMesa(new DateTime(2024, 8, 1), 55, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 39, 66, 72, 56);

            // Cuarto año
            AgregarMesa(new DateTime(2024, 7, 29), 66, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 39, 71, 43, 66);

            AgregarMesa(new DateTime(2024, 7, 30), 68, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 45, 66, 39, 28);

            AgregarMesa(new DateTime(2024, 8, 1), 73, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 16, 73, 6, 56);

            // Tecnicatura Superior en Desarrollo de Software
            // Primer año
            AgregarMesa(new DateTime(2024, 7, 24), 80, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 57, 37, 11, 59);

            AgregarMesa(new DateTime(2024, 7, 26), 85, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 64, 59, 37, 31);

            AgregarMesa(new DateTime(2024, 7, 29), 81, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 47, 22, 34, 64);

            AgregarMesa(new DateTime(2024, 7, 30), 83, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 15, 59, 5, 53);

            AgregarMesa(new DateTime(2024, 7, 31), 84, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 5, 4, 59, 57);

            AgregarMesa(new DateTime(2024, 8, 1), 82, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 53, 4, 5, 34);

            AgregarMesa(new DateTime(2024, 8, 2), 77, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 31, 64, 59, 59);

            AgregarMesa(new DateTime(2024, 8, 2), 78, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 31, 64, 59, 59);

            // Segundo año
            AgregarMesa(new DateTime(2024, 7, 23), 90, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 11, 22, 34, 15);

            AgregarMesa(new DateTime(2024, 7, 23), 86, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 22, 34, 11, 15);

            AgregarMesa(new DateTime(2024, 7, 23), 87, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 22, 34, 11, 15);

            AgregarMesa(new DateTime(2024, 7, 24), 88, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 37, 57, 11, 57);

            AgregarMesa(new DateTime(2024, 7, 30), 93, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 59, 15, 34, 53);

            AgregarMesa(new DateTime(2024, 7, 31), 92, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 4, 5, 59, 57);

            AgregarMesa(new DateTime(2024, 8, 1), 91, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 59, 53, 31, 34);

            // Tercer año
            AgregarMesa(new DateTime(2024, 7, 30), 100, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 59, 15, 34, 53);

            AgregarMesa(new DateTime(2024, 7, 24), 95, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 7, 57, 15, 15);

            AgregarMesa(new DateTime(2024, 7, 31), 99, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 59, 4, 5, 57);

            AgregarMesa(new DateTime(2024, 8, 1), 98, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 59, 53, 31, 34);

            AgregarMesa(new DateTime(2024, 8, 2), 101, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 4, 46, 47, 59);

            // Tecnicatura Superior en Infraestructura de Tecnología de la Información
            // Primer año
            AgregarMesa(new DateTime(2024, 7, 25), 161, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 15, 47, 5, 21);

            AgregarMesa(new DateTime(2024, 7, 25), 158, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 47, 15, 5, 21);

            AgregarMesa(new DateTime(2024, 8, 1), 156, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 58, 11, 54, 46);

            AgregarMesa(new DateTime(2024, 8, 2), 154, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 31, 64, 59, 58);

            AgregarMesa(new DateTime(2024, 8, 2), 155, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 31, 64, 59, 58);

            // Segundo año
            AgregarMesa(new DateTime(2024, 7, 23), 166, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 11, 22, 34, 46);

            AgregarMesa(new DateTime(2024, 7, 25), 170, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 5, 47, 15, 21);

            AgregarMesa(new DateTime(2024, 7, 30), 163, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 42, 46, 7, 53);

            AgregarMesa(new DateTime(2024, 7, 30), 164, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 42, 46, 7, 53);

            AgregarMesa(new DateTime(2024, 8, 1), 167, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 64, 21, 47, 46);

            // Tercer año
            AgregarMesa(new DateTime(2024, 7, 30), 172, "19 HS");
            AgregarDetalleMesa(mesaId - 1, 7, 46, 42, 53);

            AgregarMesa(new DateTime(2024, 7, 30), 178, "19 HS");
            AgregarDetalleMesa(mesaId - 1, 46, 7, 42, 53);

            // Tecnico Superior en Gestión de las Organizaciones
            // Primer año
            AgregarMesa(new DateTime(2024, 7, 22), 133, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 47, 60, 18, 67);

            AgregarMesa(new DateTime(2024, 7, 24), 131, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 48, 2, 31, 28);

            AgregarMesa(new DateTime(2024, 7, 26), 132, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 64, 63, 2, 33);

            AgregarMesa(new DateTime(2024, 7, 29), 129, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 34, 67, 17, 47);

            AgregarMesa(new DateTime(2024, 7, 30), 130, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 36, 29, 17, 48);

            AgregarMesa(new DateTime(2024, 7, 31), 127, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 31, 47, 67, 2);

            AgregarMesa(new DateTime(2024, 7, 31), 128, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 31, 47, 67, 2);

            AgregarMesa(new DateTime(2024, 8, 1), 134, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 67, 48, 29, 28);

            AgregarMesa(new DateTime(2024, 8, 2), 135, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 2, 60, 36, 28);

            // Tecnicatura Superior en Gestión de las Organizaciones -2do año
            AgregarMesa(new DateTime(2024, 7, 22), 140, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 60, 47, 18, 67);

            AgregarMesa(new DateTime(2024, 7, 23), 144, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 29, 7, 11, 37);

            AgregarMesa(new DateTime(2024, 7, 24), 141, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 17, 18, 7, 29);

            AgregarMesa(new DateTime(2024, 7, 26), 142, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 34, 18, 37, 33);

            AgregarMesa(new DateTime(2024, 7, 29), 138, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 34, 48, 60, 47);

            AgregarMesa(new DateTime(2024, 7, 30), 139, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 37, 7, 33, 48);

            AgregarMesa(new DateTime(2024, 7, 31), 143, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 34, 18, 48, 2);

            AgregarMesa(new DateTime(2024, 8, 1), 137, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 67, 48, 29, 29);

            AgregarMesa(new DateTime(2024, 8, 2), 136, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 63, 34, 18, 29);

            // Tecnicatura Superior en Gestión de las Organizaciones - 3er año
            AgregarMesa(new DateTime(2024, 7, 24), 151, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 18, 17, 7, 29);

            AgregarMesa(new DateTime(2024, 7, 26), 150, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 18, 34, 37, 29);

            AgregarMesa(new DateTime(2024, 7, 30), 146, "17 HS");
            AgregarDetalleMesa(mesaId - 1, 7, 37, 33, 48);

            AgregarMesa(new DateTime(2024, 7, 31), 152, "18 HS");
            AgregarDetalleMesa(mesaId - 1, 18, 34, 48, 2);


            // Tecnicatura Superior en Enfermería
            // Primer año
            AgregarMesa(new DateTime(2024, 7, 23), 106, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 61, 9, 32, 3);
            AgregarMesa(new DateTime(2024, 7, 29), 102, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 8, 9, 12, 61);
            AgregarMesa(new DateTime(2024, 7, 29), 103, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 8, 9, 12, 61);
            AgregarMesa(new DateTime(2024, 7, 30), 107, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 3, 61, 32, 9);
            AgregarMesa(new DateTime(2024, 7, 31), 105, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 54, 51, 61, 3);
            AgregarMesa(new DateTime(2024, 8, 2), 107, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 3, 51, 32, 12);
            // Segundo año
            AgregarMesa(new DateTime(2024, 7, 23), 116, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 9, 61, 32, 3);
            AgregarMesa(new DateTime(2024, 7, 24), 113, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 61, 7, 54, 61);
            AgregarMesa(new DateTime(2024, 7, 25), 112, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 68, 24, 3, 25);
            AgregarMesa(new DateTime(2024, 7, 25), 115, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 24, 68, 3, 25);
            AgregarMesa(new DateTime(2024, 7, 29), 114, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 54, 3, 51, 61);
            AgregarMesa(new DateTime(2024, 7, 31), 110, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 12, 49, 7, 3);
            AgregarMesa(new DateTime(2024, 7, 31), 111, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 49, 12, 7, 3);
            // Tercer año
            AgregarMesa(new DateTime(2024, 7, 24), 119, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 7, 61, 54, 61);
            AgregarMesa(new DateTime(2024, 7, 24), 120, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 30, 35, 31, 61);
            AgregarMesa(new DateTime(2024, 7, 25), 121, "10 HS");
            AgregarDetalleMesa(mesaId - 1, 37, 68, 25, 25);
            AgregarMesa(new DateTime(2024, 7, 26), 123, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 9, 32, 51, 3);
            AgregarMesa(new DateTime(2024, 7, 29), 125, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 3, 54, 51, 61);
            AgregarMesa(new DateTime(2024, 7, 30), 124, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 61, 3, 32, 9);
            AgregarMesa(new DateTime(2024, 8, 1), 122, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 25, 68, 51, 9);
            // Profesorado de Educación Secundaria en Ciencias de la Administración
            // Primer año
            AgregarMesa(new DateTime(2024, 7, 22), 229, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 39, 72, 20, 2);
            AgregarMesa(new DateTime(2024, 7, 23), 224, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 28, 72, 17, 34);
            AgregarMesa(new DateTime(2024, 7, 24), 226, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 17, 22, 44, 47);
            AgregarMesa(new DateTime(2024, 7, 24), 227, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 17, 22, 44, 47);
            AgregarMesa(new DateTime(2024, 7, 29), 225, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 42, 71, 60, 48);
            AgregarMesa(new DateTime(2024, 7, 31), 228, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 34, 48, 44, 22);
            AgregarMesa(new DateTime(2024, 7, 31), 231, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 44, 48, 34, 22);
            AgregarMesa(new DateTime(2024, 8, 1), 230, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 60, 28, 55, 28);
            // Segundo año
            AgregarMesa(new DateTime(2024, 7, 22), 235, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 72, 39, 20, 34);
            AgregarMesa(new DateTime(2024, 7, 25), 240, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 11, 30, 31, 36);
            AgregarMesa(new DateTime(2024, 7, 25), 238, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 30, 11, 31, 36);
            AgregarMesa(new DateTime(2024, 7, 26), 233, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 49, 28, 71, 2);
            AgregarMesa(new DateTime(2024, 7, 29), 239, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 60, 42, 71, 48);
            AgregarMesa(new DateTime(2024, 7, 30), 234, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 28, 64, 30, 17);
            AgregarMesa(new DateTime(2024, 7, 31), 237, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 34, 48, 44, 22);
            // Tercer año
            AgregarMesa(new DateTime(2024, 7, 23), 251, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 72, 28, 17, 34);
            AgregarMesa(new DateTime(2024, 7, 24), 246, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 22, 17, 44, 47);
            AgregarMesa(new DateTime(2024, 7, 25), 249, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 30, 11, 31, 36);
            AgregarMesa(new DateTime(2024, 7, 26), 243, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 28, 49, 71, 2);
            AgregarMesa(new DateTime(2024, 7, 29), 245, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 71, 42, 60, 48);
            AgregarMesa(new DateTime(2024, 8, 1), 244, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 28, 60, 55, 27);
            // Cuarto año
            AgregarMesa(new DateTime(2024, 7, 30), 263, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 64, 28, 30, 17);
            AgregarMesa(new DateTime(2024, 7, 31), 259, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 48, 44, 34, 22);
            // Profesorado de Educación Inicial
            // Primer año
            AgregarMesa(new DateTime(2024, 7, 22), 182, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 42, 54, 31, 44);
            AgregarMesa(new DateTime(2024, 7, 22), 189, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 54, 42, 31, 44);
            AgregarMesa(new DateTime(2024, 7, 24), 180, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 49, 69, 72, 10);
            AgregarMesa(new DateTime(2024, 7, 25), 185, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 43, 49, 54, 36);
            AgregarMesa(new DateTime(2024, 7, 30), 179, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 10, 13, 65, 69);
            AgregarMesa(new DateTime(2024, 8, 2), 181, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 73, 40, 10, 72);
            // Segundo año
            AgregarMesa(new DateTime(2024, 7, 22), 201, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 54, 42, 31, 44);
            AgregarMesa(new DateTime(2024, 7, 24), 200, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 69, 49, 72, 10);
            AgregarMesa(new DateTime(2024, 7, 25), 198, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 49, 43, 54, 36);
            AgregarMesa(new DateTime(2024, 7, 30), 197, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 13, 10, 65, 69);
            AgregarMesa(new DateTime(2024, 7, 30), 195, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 65, 10, 13, 69);
            AgregarMesa(new DateTime(2024, 8, 1), 199, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 44, 11, 36, 49);
            AgregarMesa(new DateTime(2024, 8, 2), 192, "13 HS");
            AgregarDetalleMesa(mesaId - 1, 40, 73, 10, 72);

            // Profesorado de Educación Inicial - 3er año
            AgregarMesa(new DateTime(2024, 7, 24), 209, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 69, 52, 42, 54);

            AgregarMesa(new DateTime(2024, 7, 25), 204, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 21, 68, 19, 54);

            AgregarMesa(new DateTime(2024, 7, 26), 205, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 27, 39, 14, 54);

            AgregarMesa(new DateTime(2024, 7, 29), 207, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 44, 11, 19, 54);

            AgregarMesa(new DateTime(2024, 7, 31), 206, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 72, 71, 50, 3);

            AgregarMesa(new DateTime(2024, 8, 1), 210, "10 HS");
            AgregarDetalleMesa(mesaId - 1, 39, 60, 27, 12);

            AgregarMesa(new DateTime(2024, 8, 2), 214, "10 HS");
            AgregarDetalleMesa(mesaId - 1, 39, 60, 27, 62);

            AgregarMesa(new DateTime(2024, 8, 2), 215, "10 HS");
            AgregarDetalleMesa(mesaId - 1, 39, 60, 27, 62);

            // Profesorado de Educación Inicial - 4to año
            AgregarMesa(new DateTime(2024, 7, 26), 219, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 64, 2, 60, 54);

            AgregarMesa(new DateTime(2024, 7, 31), 221, "8 HS");
            AgregarDetalleMesa(mesaId - 1, 71, 50, 72, 30);

            AgregarMesa(new DateTime(2024, 8, 1), 218, "11 HS");
            AgregarDetalleMesa(mesaId - 1, 39, 27, 14, 12);

            modelBuilder.Entity<MesaExamen>().HasData(mesasExamen);
            modelBuilder.Entity<DetalleMesaExamen>().HasData(detallesMesaExamen);
            #endregion
            
            #region metodos datos semillas Horario DetalleHorario IntegranteHorario
            var horarioId = 1;
            var horarios = new List<Horario>();
            var detalleHorarioId = 1;
            var detallesHorario = new List<DetalleHorario>();
            var integranteHorarioId = 1;
            var integrantesHorario = new List<IntegranteHorario>();
            void AgregarHorario(int materiaId, int cantidadHoras, int cicloLectivoId)
            {
                horarios.Add(new Horario
                {
                    Id = horarioId++,
                    MateriaId = materiaId,
                    CantidadHoras = cantidadHoras,
                    CicloLectivoId = cicloLectivoId
                });
            }

            void AgregarDetalleHorario(int horarioId, DiaEnum dia, int horaId)
            {
                detallesHorario.Add(new DetalleHorario
                {
                    Id = detalleHorarioId++,
                    HorarioId = horarioId,
                    Dia = dia,
                    HoraId = horaId
                });
            }

            void AgregarIntegranteHorario(int horarioId, int docenteId)
            {
                integrantesHorario.Add(new IntegranteHorario
                {
                    Id = integranteHorarioId++,
                    HorarioId = horarioId,
                    DocenteId = docenteId
                });
            }


            #endregion
            
            #region tecnologia
            /*
            // 1er año - Profesorado de Educación Tecnológica

            // Pedagogía
            AgregarHorario(38, 3, 1);
            AgregarDetalleHorario(1, DiaEnum.Miércoles, 1);
            AgregarDetalleHorario(1, DiaEnum.Miércoles, 2);
            AgregarDetalleHorario(1, DiaEnum.Miércoles, 3);
            AgregarIntegranteHorario(1, 71); // Verzzali, A.

            // Movimiento y Cuerpo
            AgregarHorario(39, 3, 1);
            AgregarDetalleHorario(2, DiaEnum.Martes, 6);
            AgregarDetalleHorario(2, DiaEnum.Martes, 8);
            AgregarDetalleHorario(2, DiaEnum.Martes, 10);
            AgregarIntegranteHorario(2, 65); // Sancho, I.

            // Práctica Docente I: Escenarios Educativos
            AgregarHorario(40, 3, 1);
            AgregarDetalleHorario(3, DiaEnum.Viernes, 1);
            AgregarDetalleHorario(3, DiaEnum.Viernes, 2);
            AgregarDetalleHorario(3, DiaEnum.Viernes, 3);
            AgregarIntegranteHorario(3, 73); // Villa, M.F.
            AgregarIntegranteHorario(3, 6);  // Arnolfo, P.

            // Introducción a la Tecnología
            AgregarHorario(41, 3, 1);
            AgregarDetalleHorario(4, DiaEnum.Miércoles, 6);
            AgregarDetalleHorario(4, DiaEnum.Miércoles, 8);
            AgregarDetalleHorario(4, DiaEnum.Miércoles, 10);
            AgregarIntegranteHorario(4, 66); // Sara, J.

            // Historia de la Tecnología
            AgregarHorario(42, 3, 1);
            AgregarDetalleHorario(5, DiaEnum.Viernes, 6);
            AgregarDetalleHorario(5, DiaEnum.Viernes, 8);
            AgregarDetalleHorario(5, DiaEnum.Viernes, 10);
            AgregarIntegranteHorario(5, 6); // Arnolfo, P.

            // Diseño y Producción de la Tecnología I
            AgregarHorario(43, 6, 1);
            AgregarDetalleHorario(6, DiaEnum.Lunes, 8);
            AgregarDetalleHorario(6, DiaEnum.Lunes, 10);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 6);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 8);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 10);
            AgregarDetalleHorario(6, DiaEnum.Lunes, 28);
            AgregarIntegranteHorario(6, 38); // Imhof, R.
            AgregarIntegranteHorario(6, 26); // Epes, B.

            // Matemática
            AgregarHorario(44, 6, 1);
            AgregarDetalleHorario(7, DiaEnum.Lunes, 1);
            AgregarDetalleHorario(7, DiaEnum.Lunes, 2);
            AgregarDetalleHorario(7, DiaEnum.Martes, 1);
            AgregarDetalleHorario(7, DiaEnum.Martes, 2);
            AgregarDetalleHorario(7, DiaEnum.Martes, 3);
            AgregarDetalleHorario(7, DiaEnum.Jueves, 28);
            AgregarIntegranteHorario(7, 11); // Brussa, G.

            // Física
            AgregarHorario(45, 5, 1);
            AgregarDetalleHorario(8, DiaEnum.Lunes, 3);
            AgregarDetalleHorario(8, DiaEnum.Lunes, 6);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 1);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 2);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 3);
            AgregarIntegranteHorario(8, 38); // Imhof, R.

            // Recreo
            AgregarHorario(264, 1, 1);
            AgregarDetalleHorario(9, DiaEnum.Lunes, 33);
            AgregarDetalleHorario(9, DiaEnum.Martes, 33);
            AgregarDetalleHorario(9, DiaEnum.Miércoles, 33);
            AgregarDetalleHorario(9, DiaEnum.Jueves, 33);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 33);

            // 2do año - Profesorado de Educación Tecnológica

            // Psicología
            AgregarHorario(46, 3, 1);
            AgregarDetalleHorario(1, DiaEnum.Martes, 26);
            AgregarDetalleHorario(1, DiaEnum.Martes, 28);
            AgregarDetalleHorario(1, DiaEnum.Viernes, 26);
            AgregarIntegranteHorario(1, 39); // Imperiale, M.

            // Didáctica y Curriculum
            AgregarHorario(47, 4, 1);
            AgregarDetalleHorario(2, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(2, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(2, DiaEnum.Jueves, 22);
            AgregarDetalleHorario(2, DiaEnum.Jueves, 24);
            AgregarIntegranteHorario(2, 28); // Ferreyra, M.

            // Instituciones Educativas
            AgregarHorario(48, 3, 1);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 28);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 30);
            AgregarIntegranteHorario(3, 73); // Villa, M.F.

            // Práctica Docente II: La Institución Escolar
            AgregarHorario(49, 4, 1);
            AgregarDetalleHorario(4, DiaEnum.Lunes, 30);
            AgregarDetalleHorario(4, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(4, DiaEnum.Lunes, 36);
            AgregarDetalleHorario(4, DiaEnum.Lunes, 38);
            AgregarIntegranteHorario(4, 73); // Villa, M.F.
            AgregarIntegranteHorario(4, 26); // Epes, B.

            // Sujetos de la Educación I
            AgregarHorario(50, 2, 1);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 22);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 24);
            AgregarIntegranteHorario(5, 73); // Villa, M.F.

            // TICs para la Enseñanza
            AgregarHorario(51, 3, 1);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 36);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 38);
            AgregarIntegranteHorario(6, 29); // Ferrero, M.

            // Procesos Productivos
            AgregarHorario(52, 4, 1);
            AgregarDetalleHorario(7, DiaEnum.Martes, 30);
            AgregarDetalleHorario(7, DiaEnum.Martes, 34);
            AgregarDetalleHorario(7, DiaEnum.Martes, 36);
            AgregarDetalleHorario(7, DiaEnum.Martes, 38);
            AgregarIntegranteHorario(7, 47); // Miñoz, A.

            // Diseño y Producción Tecnológica II
            AgregarHorario(53, 4, 1);
            AgregarDetalleHorario(8, DiaEnum.Miércoles, 28);
            AgregarDetalleHorario(8, DiaEnum.Miércoles, 30);
            AgregarDetalleHorario(8, DiaEnum.Miércoles, 34);
            AgregarDetalleHorario(8, DiaEnum.Miércoles, 36);
            AgregarIntegranteHorario(8, 38); // Imhof, R.

            // Didáctica Específica I
            AgregarHorario(54, 3, 1);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 30);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 34);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 36);
            AgregarIntegranteHorario(9, 6); // Arnolfo, P.

            // Recreo
            AgregarHorario(265, 1, 1);
            AgregarDetalleHorario(10, DiaEnum.Lunes, 33);
            AgregarDetalleHorario(10, DiaEnum.Martes, 33);
            AgregarDetalleHorario(10, DiaEnum.Miércoles, 33);
            AgregarDetalleHorario(10, DiaEnum.Jueves, 33);
            AgregarDetalleHorario(10, DiaEnum.Viernes, 33);

            // 3er año - Profesorado de Educación Tecnológica

            // Química
            AgregarHorario(61, 4, 1);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 22);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 24);
            AgregarDetalleHorario(11, DiaEnum.Martes, 34);
            AgregarDetalleHorario(11, DiaEnum.Martes, 36);
            AgregarIntegranteHorario(11, 23); // Dellaferrera, C.

            // Metodología de la Investigación
            AgregarHorario(57, 2, 1);
            AgregarDetalleHorario(12, DiaEnum.Martes, 24);
            AgregarDetalleHorario(12, DiaEnum.Martes, 26);
            AgregarIntegranteHorario(12, 43); // Manattini, S.

            // Tecnologías Regionales
            AgregarHorario(63, 3, 1);
            AgregarDetalleHorario(13, DiaEnum.Miércoles, 22);
            AgregarDetalleHorario(13, DiaEnum.Miércoles, 24);
            AgregarDetalleHorario(13, DiaEnum.Miércoles, 26);
            AgregarIntegranteHorario(13, 66); // Sara, J.

            // Filosofía
            AgregarHorario(55, 3, 1);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 24);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 28);
            AgregarIntegranteHorario(14, 39); // Imperiale, M.

            // Didáctica Específica II
            AgregarHorario(65, 4, 1);
            AgregarDetalleHorario(15, DiaEnum.Viernes, 24);
            AgregarDetalleHorario(15, DiaEnum.Viernes, 26);
            AgregarDetalleHorario(15, DiaEnum.Jueves, 30);
            AgregarDetalleHorario(15, DiaEnum.Jueves, 34);
            AgregarIntegranteHorario(15, 6); // Arnolfo, P.

            // Procesos de Control
            AgregarHorario(62, 3, 1);
            AgregarDetalleHorario(16, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(16, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(16, DiaEnum.Lunes, 30);
            AgregarIntegranteHorario(16, 16); // Cavallini, J.

            // Sujeto II
            AgregarHorario(59, 4, 1);
            AgregarDetalleHorario(17, DiaEnum.Martes, 28);
            AgregarDetalleHorario(17, DiaEnum.Martes, 30);
            AgregarDetalleHorario(17, DiaEnum.Miércoles, 28);
            AgregarDetalleHorario(17, DiaEnum.Miércoles, 30);
            AgregarIntegranteHorario(17, 73); // Villa, M.F.

            // Historia Social de la Educación
            AgregarHorario(56, 3, 1);
            AgregarDetalleHorario(18, DiaEnum.Viernes, 30);
            AgregarDetalleHorario(18, DiaEnum.Viernes, 34);
            AgregarDetalleHorario(18, DiaEnum.Viernes, 36);
            AgregarIntegranteHorario(18, 28); // Ferreyra, M.

            // Práctica Docente III: La Clase
            AgregarHorario(58, 3, 1);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 36);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 38);
            AgregarIntegranteHorario(19, 72); // Vignatti, E.
            AgregarIntegranteHorario(19, 66); // Sara, J.

            // Diseño y Producción Tecnológica III
            AgregarHorario(64, 4, 1);
            AgregarDetalleHorario(20, DiaEnum.Miércoles, 34);
            AgregarDetalleHorario(20, DiaEnum.Miércoles, 36);
            AgregarDetalleHorario(20, DiaEnum.Jueves, 36);
            AgregarDetalleHorario(20, DiaEnum.Jueves, 38);
            AgregarIntegranteHorario(20, 6); // Arnolfo, P.

            // Recreo
            AgregarHorario(266, 1, 1);
            AgregarDetalleHorario(21, DiaEnum.Lunes, 33);
            AgregarDetalleHorario(21, DiaEnum.Martes, 33);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 33);
            AgregarDetalleHorario(21, DiaEnum.Jueves, 33);
            AgregarDetalleHorario(21, DiaEnum.Viernes, 33);

            // 4to año - Profesorado de Educación Tecnológica

            // Ética y Trabajo Docente
            AgregarHorario(66, 2, 1);
            AgregarDetalleHorario(10, DiaEnum.Miércoles, 30);
            AgregarDetalleHorario(10, DiaEnum.Miércoles, 34);
            AgregarIntegranteHorario(10, 39); // Imperiale, M.

            // Educación Sexual Integral
            AgregarHorario(67, 3, 1);
            AgregarDetalleHorario(11, DiaEnum.Miércoles, 24);
            AgregarDetalleHorario(11, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(11, DiaEnum.Miércoles, 28);
            AgregarIntegranteHorario(11, 54); // Pereyra, S.

            // Unidades de Definición Institucional I
            AgregarHorario(68, 3, 1);
            AgregarDetalleHorario(12, DiaEnum.Martes, 34);
            AgregarDetalleHorario(12, DiaEnum.Martes, 36);
            AgregarDetalleHorario(12, DiaEnum.Martes, 38);
            AgregarIntegranteHorario(12, 45); // Martínez, G.

            // Prácticas de Investigación
            AgregarHorario(70, 3, 1);
            AgregarDetalleHorario(13, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(13, DiaEnum.Jueves, 36);
            AgregarDetalleHorario(13, DiaEnum.Jueves, 38);
            AgregarIntegranteHorario(13, 75); // Sager, L.
            AgregarIntegranteHorario(13, 66); // Sara, J.

            // Práctica Docente IV: El Rol Docente y su Práctica
            AgregarHorario(71, 4, 1);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 28);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 30);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 34);
            AgregarIntegranteHorario(14, 75); // Sager, L.
            AgregarIntegranteHorario(14, 66); // Sara, J.

            // Biotecnología
            AgregarHorario(72, 3, 1);
            AgregarDetalleHorario(15, DiaEnum.Viernes, 28);
            AgregarDetalleHorario(15, DiaEnum.Viernes, 30);
            AgregarDetalleHorario(15, DiaEnum.Viernes, 34);
            AgregarIntegranteHorario(15, 23); // Dellaferrera, C.

            // Procesos de Comunicación
            AgregarHorario(73, 3, 1);
            AgregarDetalleHorario(16, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(16, DiaEnum.Lunes, 36);
            AgregarDetalleHorario(16, DiaEnum.Lunes, 38);
            AgregarIntegranteHorario(16, 16); // Cavallini, J.

            // Diseño y Producción Tecnológica IV
            AgregarHorario(75, 3, 1);
            AgregarDetalleHorario(17, DiaEnum.Martes, 26);
            AgregarDetalleHorario(17, DiaEnum.Martes, 28);
            AgregarDetalleHorario(17, DiaEnum.Martes, 30);
            AgregarIntegranteHorario(17, 66); // Sara, J.

            // Taller de Producción Didáctica
            AgregarHorario(76, 3, 1);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 30);
            AgregarIntegranteHorario(18, 66); // Sara, J.

            // Recreo
            AgregarHorario(267, 1, 1);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 33);
            AgregarDetalleHorario(19, DiaEnum.Martes, 33);
            AgregarDetalleHorario(19, DiaEnum.Miércoles, 33);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 33);
            AgregarDetalleHorario(19, DiaEnum.Viernes, 33);
            */
            #endregion
            
            #region tsgo
            
            // 1er año - Tecnicatura Superior en Gestión de las Organizaciones

            // Economía
            AgregarHorario(7, 3, 1);
            AgregarDetalleHorario(1, DiaEnum.Martes, 24);
            AgregarDetalleHorario(1, DiaEnum.Martes, 26);
            AgregarDetalleHorario(1, DiaEnum.Martes, 28);
            AgregarIntegranteHorario(1, 34); // Gongora L.

            // Gestión del Capital Humano
            AgregarHorario(135, 4, 1);
            AgregarDetalleHorario(2, DiaEnum.Miércoles, 24);
            AgregarDetalleHorario(2, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(2, DiaEnum.Viernes, 28);
            AgregarDetalleHorario(2, DiaEnum.Viernes, 30);
            AgregarIntegranteHorario(2, 2); // Aimar M.A.

            // Gestión de la Producción
            AgregarHorario(134, 4, 1);
            AgregarDetalleHorario(3, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(3, DiaEnum.Lunes, 30);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 36);
            AgregarIntegranteHorario(3, 67); // Strada J.

            // Matemática y Estadística
            AgregarHorario(130, 4, 1);
            AgregarDetalleHorario(4, DiaEnum.Martes, 34);
            AgregarDetalleHorario(4, DiaEnum.Martes, 36);
            AgregarDetalleHorario(4, DiaEnum.Martes, 38);
            AgregarDetalleHorario(4, DiaEnum.Martes, 38);
            AgregarIntegranteHorario(4, 36); // Gretter C.

            // Administración
            AgregarHorario(133, 3, 1);
            AgregarDetalleHorario(5, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(5, DiaEnum.Lunes, 36);
            AgregarDetalleHorario(5, DiaEnum.Lunes, 38);
            AgregarIntegranteHorario(5, 47); // Miñoz

            // Contabilidad
            AgregarHorario(131, 4, 1);
            AgregarDetalleHorario(6, DiaEnum.Miércoles, 28);
            AgregarDetalleHorario(6, DiaEnum.Miércoles, 30);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 28);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 30);
            AgregarIntegranteHorario(6, 48); // Molina T.

            // Comunicación
            AgregarHorario(127, 3, 1);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 34);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 36);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 38);
            AgregarIntegranteHorario(7, 31); // Gaido J.P.

            // Informática
            AgregarHorario(132, 3, 1);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 34);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 36);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 38);
            AgregarIntegranteHorario(8, 64); // Sandoval P.

            // Recreo
            AgregarHorario(264, 1, 1);
            AgregarDetalleHorario(9, DiaEnum.Lunes, 33);

            // 2do año - Tecnicatura Superior en Gestión de las Organizaciones

            // Gestión de la Comercialización
            AgregarHorario(141, 5, 1);
            AgregarDetalleHorario(10, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(10, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(10, DiaEnum.Lunes, 30);
            AgregarDetalleHorario(10, DiaEnum.Martes, 28);
            AgregarDetalleHorario(10, DiaEnum.Martes, 30);
            AgregarIntegranteHorario(10, 17); // Chauderon L.

            // Innovación y Desarrollo Emprendedor
            AgregarHorario(138, 3, 1);
            AgregarDetalleHorario(11, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(11, DiaEnum.Miércoles, 28);
            AgregarDetalleHorario(11, DiaEnum.Miércoles, 30);
            AgregarIntegranteHorario(11, 34); // Gongora L.

            // Práctica Profesionalizante
            AgregarHorario(144, 4, 1);
            AgregarDetalleHorario(12, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(12, DiaEnum.Jueves, 28);
            AgregarDetalleHorario(12, DiaEnum.Jueves, 30);
            AgregarDetalleHorario(12, DiaEnum.Jueves, 34);
            AgregarIntegranteHorario(12, 29); // Ferrero Marcela

            // Gestión de Costos
            AgregarHorario(142, 3, 1);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 26);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 28);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 30);
            AgregarIntegranteHorario(13, 34); // Gongora L.

            // Legislación Comercial y Tributaria
            AgregarHorario(140, 3, 1);
            AgregarDetalleHorario(14, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(14, DiaEnum.Lunes, 36);
            AgregarDetalleHorario(14, DiaEnum.Lunes, 38);
            AgregarIntegranteHorario(14, 60); // Renteria M.D.

            // Inglés Técnico
            AgregarHorario(139, 3, 1);
            AgregarDetalleHorario(15, DiaEnum.Martes, 34);
            AgregarDetalleHorario(15, DiaEnum.Martes, 36);
            AgregarDetalleHorario(15, DiaEnum.Martes, 38);
            AgregarIntegranteHorario(15, 37); // Grosso S

            // Gestión Contable
            AgregarHorario(143, 3, 1);
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 34);
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 36);
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 38);
            AgregarIntegranteHorario(16, 34); // Gongora L.

            // Problemáticas Contemporáneas
            AgregarHorario(136, 3, 1);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 34);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 36);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 38);
            AgregarIntegranteHorario(17, 63); // Sanchez

            // Recreo
            AgregarHorario(265, 1, 1);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 33);

            // 3er año - Tecnicatura Superior en Gestión de las Organizaciones

            // Estrategia Empresarial
            AgregarHorario(148, 5, 1);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 28);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 30);
            AgregarIntegranteHorario(19, 33); // Genero A.

            // Práctica Profesionalizante
            AgregarHorario(153, 3, 1);
            AgregarDetalleHorario(20, DiaEnum.Martes, 26);
            AgregarDetalleHorario(20, DiaEnum.Martes, 28);
            AgregarDetalleHorario(20, DiaEnum.Martes, 30);
            AgregarIntegranteHorario(20, 29); // Ferrero M

            // Gestión de Seguridad, Salud Ocupacional y M.A.
            AgregarHorario(145, 3, 1);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 28);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 30);
            AgregarIntegranteHorario(21, 67); // Strada J.

            // Gestión de Control
            AgregarHorario(152, 3, 1);
            AgregarDetalleHorario(22, DiaEnum.Viernes, 26);
            AgregarDetalleHorario(22, DiaEnum.Viernes, 28);
            AgregarDetalleHorario(22, DiaEnum.Viernes, 30);
            AgregarIntegranteHorario(22, 18); // Chelini

            // Evaluación Proyectos de Inversión
            AgregarHorario(151, 3, 1);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 30);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 36);
            AgregarIntegranteHorario(23, 18); // Chelini V.

            // Legislación Laboral
            AgregarHorario(147, 3, 1);
            AgregarDetalleHorario(24, DiaEnum.Martes, 34);
            AgregarDetalleHorario(24, DiaEnum.Martes, 36);
            AgregarDetalleHorario(24, DiaEnum.Martes, 38);
            AgregarIntegranteHorario(24, 29); // Ferrero M.

            // Sistema de Información para la Gestión de las Org.
            AgregarHorario(149, 3, 1);
            AgregarDetalleHorario(25, DiaEnum.Miércoles, 34);
            AgregarDetalleHorario(25, DiaEnum.Miércoles, 36);
            AgregarDetalleHorario(25, DiaEnum.Miércoles, 38);
            AgregarIntegranteHorario(25, 47); // Miñoz A.

            // Gestión Financiera
            AgregarHorario(150, 3, 1);
            AgregarDetalleHorario(26, DiaEnum.Viernes, 34);
            AgregarDetalleHorario(26, DiaEnum.Viernes, 36);
            AgregarDetalleHorario(26, DiaEnum.Viernes, 38);
            AgregarIntegranteHorario(26, 18); // Chelini V.

            // Recreo
            AgregarHorario(266, 1, 1);
            AgregarDetalleHorario(27, DiaEnum.Lunes, 33);
            
            #endregion
            
            #region infraestructura
            /*
            // 1er año
            AgregarHorario(157, 4, 1); // Física Aplicada a las Tecnologías de la Información
            AgregarDetalleHorario(1, DiaEnum.Viernes, 34);
            AgregarDetalleHorario(1, DiaEnum.Viernes, 36);
            AgregarDetalleHorario(1, DiaEnum.Viernes, 38);
            AgregarIntegranteHorario(1, 53); // Pedrazzoli

            AgregarHorario(158, 3, 1); // Administración
            AgregarDetalleHorario(2, DiaEnum.Jueves, 30);
            AgregarDetalleHorario(2, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(2, DiaEnum.Jueves, 36);
            AgregarIntegranteHorario(2, 47); // Miñoz

            AgregarHorario(159, 4, 1); // Inglés Técnico
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 22);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 24);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 28);
            AgregarIntegranteHorario(3, 57); // Puccio

            AgregarHorario(160, 4, 1); // Arquitectura de las Computadoras
            AgregarDetalleHorario(4, DiaEnum.Martes, 30);
            AgregarDetalleHorario(4, DiaEnum.Martes, 34);
            AgregarDetalleHorario(4, DiaEnum.Martes, 36);
            AgregarDetalleHorario(4, DiaEnum.Martes, 38);
            AgregarIntegranteHorario(4, 53); // Pedrazzoli

            AgregarHorario(161, 4, 1); // Lógica y Programación
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 30);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 34);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 36);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 38);
            AgregarIntegranteHorario(5, 15); // Calvo, M.

            AgregarHorario(162, 4, 1); // Infraestructura de Redes I
            AgregarDetalleHorario(6, DiaEnum.Martes, 22);
            AgregarDetalleHorario(6, DiaEnum.Martes, 24);
            AgregarDetalleHorario(6, DiaEnum.Martes, 26);
            AgregarDetalleHorario(6, DiaEnum.Martes, 28);
            AgregarIntegranteHorario(6, 46); // Mendoza, M.

            AgregarHorario(156, 3, 1); // Matemática
            AgregarDetalleHorario(7, DiaEnum.Viernes, 26);
            AgregarDetalleHorario(7, DiaEnum.Viernes, 28);
            AgregarDetalleHorario(7, DiaEnum.Viernes, 30);
            AgregarIntegranteHorario(7, 58); // Quaglia, E.

            AgregarHorario(154, 2, 1); // Comunicación
            AgregarDetalleHorario(8, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 28);
            AgregarIntegranteHorario(8, 31); // Gaido, J.P.

            AgregarHorario(264, 1, 1); // Recreo
            AgregarDetalleHorario(9, DiaEnum.Martes, 33);

            AgregarHorario(265, 1, 1); // Recreo
            AgregarDetalleHorario(10, DiaEnum.Miércoles, 33);

            AgregarHorario(266, 1, 1); // Recreo
            AgregarDetalleHorario(11, DiaEnum.Jueves, 33);

            AgregarHorario(267, 1, 1); // Recreo
            AgregarDetalleHorario(12, DiaEnum.Viernes, 33);

            // 2do año
            AgregarHorario(163, 3, 1); // Problemáticas Socio Contemporáneas
            AgregarDetalleHorario(13, DiaEnum.Martes, 24);
            AgregarDetalleHorario(13, DiaEnum.Martes, 26);
            AgregarDetalleHorario(13, DiaEnum.Martes, 28);
            AgregarIntegranteHorario(13, 42); // Mancilla, J.

            AgregarHorario(165, 3, 1); // Innovación y Desarrollo Emprendedor
            AgregarDetalleHorario(14, DiaEnum.Lunes, 24);
            AgregarDetalleHorario(14, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(14, DiaEnum.Lunes, 28);
            AgregarIntegranteHorario(14, 34); // Gongora, L.

            AgregarHorario(166, 3, 1); // Estadística
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 30);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 34);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 36);
            AgregarIntegranteHorario(15, 11); // Brussa, G.

            AgregarHorario(167, 4, 1); // Sistemas Operativos
            AgregarDetalleHorario(16, DiaEnum.Jueves, 22);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 24);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 28);
            AgregarIntegranteHorario(16, 64); // Sandoval, P.

            AgregarHorario(168, 4, 1); // Algoritmos y Estructuras de Datos
            AgregarDetalleHorario(17, DiaEnum.Miércoles, 22);
            AgregarDetalleHorario(17, DiaEnum.Miércoles, 24);
            AgregarDetalleHorario(17, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(17, DiaEnum.Miércoles, 28);
            AgregarIntegranteHorario(17, 46); // Mendoza

            AgregarHorario(169, 4, 1); // Base de Datos
            AgregarDetalleHorario(18, DiaEnum.Lunes, 30);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 36);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 38);
            AgregarIntegranteHorario(18, 46); // Mendoza

            AgregarHorario(170, 4, 1); // Infraestructura de Redes II
            AgregarDetalleHorario(19, DiaEnum.Martes, 30);
            AgregarDetalleHorario(19, DiaEnum.Martes, 34);
            AgregarDetalleHorario(19, DiaEnum.Martes, 36);
            AgregarDetalleHorario(19, DiaEnum.Martes, 38);
            AgregarIntegranteHorario(19, 5); // Alesso, M.

            AgregarHorario(171, 4, 1); // Práctica Profesionalizante I
            AgregarDetalleHorario(20, DiaEnum.Jueves, 30);
            AgregarDetalleHorario(20, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(20, DiaEnum.Jueves, 36);
            AgregarDetalleHorario(20, DiaEnum.Jueves, 38);
            AgregarIntegranteHorario(20, 21); // Degiorgio, O.

            AgregarHorario(268, 1, 1); // Recreo
            AgregarDetalleHorario(21, DiaEnum.Lunes, 33);

            AgregarHorario(269, 1, 1); // Recreo
            AgregarDetalleHorario(22, DiaEnum.Martes, 33);

            AgregarHorario(270, 1, 1); // Recreo
            AgregarDetalleHorario(23, DiaEnum.Miércoles, 33);

            AgregarHorario(271, 1, 1); // Recreo
            AgregarDetalleHorario(24, DiaEnum.Jueves, 33);

            // 3er año
            AgregarHorario(172, 3, 1); // Ética y Responsabilidad Social
            AgregarDetalleHorario(25, DiaEnum.Martes, 24);
            AgregarDetalleHorario(25, DiaEnum.Martes, 26);
            AgregarDetalleHorario(25, DiaEnum.Martes, 28);
            AgregarIntegranteHorario(25, 29); // Ferrero, M.

            AgregarHorario(173, 3, 1); // Derecho y Legislación Laboral
            AgregarDetalleHorario(26, DiaEnum.Martes, 24);
            AgregarDetalleHorario(26, DiaEnum.Martes, 26);
            AgregarDetalleHorario(26, DiaEnum.Martes, 28);
            AgregarIntegranteHorario(26, 29); // Ferrero, M.

            AgregarHorario(174, 4, 1); // Administración de Base de Datos
            AgregarDetalleHorario(27, DiaEnum.Lunes, 30);
            AgregarDetalleHorario(27, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(27, DiaEnum.Lunes, 36);
            AgregarDetalleHorario(27, DiaEnum.Lunes, 38);
            AgregarIntegranteHorario(27, 59); // Ramirez, R.A.

            AgregarHorario(175, 4, 1); // Integridad y Migración de Datos
            AgregarDetalleHorario(28, DiaEnum.Jueves, 30);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 36);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 38);
            AgregarIntegranteHorario(28, 59); // Ramirez, R.A.

            AgregarHorario(176, 5, 1); // Seguridad de los Sistemas
            AgregarDetalleHorario(29, DiaEnum.Viernes, 24);
            AgregarDetalleHorario(29, DiaEnum.Viernes, 26);
            AgregarDetalleHorario(29, DiaEnum.Viernes, 28);
            AgregarDetalleHorario(29, DiaEnum.Viernes, 30);
            AgregarDetalleHorario(29, DiaEnum.Viernes, 34);
            AgregarIntegranteHorario(29, 46); // Mendoza, M.

            AgregarHorario(177, 4, 1); // Administración de Sistemas Operativos y Redes
            AgregarDetalleHorario(30, DiaEnum.Martes, 30);
            AgregarDetalleHorario(30, DiaEnum.Martes, 34);
            AgregarDetalleHorario(30, DiaEnum.Martes, 36);
            AgregarDetalleHorario(30, DiaEnum.Martes, 38);
            AgregarIntegranteHorario(30, 46); // Mendoza

            AgregarHorario(178, 5, 1); // Práctica Profesionalizante II
            AgregarDetalleHorario(31, DiaEnum.Lunes, 22);
            AgregarDetalleHorario(31, DiaEnum.Lunes, 24);
            AgregarDetalleHorario(31, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(31, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(31, DiaEnum.Miércoles, 30);
            AgregarIntegranteHorario(31, 46); // Mendoza, M.

            AgregarHorario(272, 1, 1); // Recreo
            AgregarDetalleHorario(32, DiaEnum.Lunes, 33);

            AgregarHorario(273, 1, 1); // Recreo
            AgregarDetalleHorario(33, DiaEnum.Martes, 33);

            AgregarHorario(274, 1, 1); // Recreo
            AgregarDetalleHorario(34, DiaEnum.Miércoles, 33);

            AgregarHorario(275, 1, 1); // Recreo
            AgregarDetalleHorario(35, DiaEnum.Jueves, 33);

            AgregarHorario(276, 1, 1); // Recreo
            AgregarDetalleHorario(36, DiaEnum.Viernes, 33);
            #endregion
            #region software
            // 1° Año
            AgregarHorario(77, 3, 1); // Comunicación
            AgregarDetalleHorario(1, DiaEnum.Viernes, 16);
            AgregarDetalleHorario(1, DiaEnum.Viernes, 17);
            AgregarDetalleHorario(1, DiaEnum.Viernes, 18);
            AgregarIntegranteHorario(1, 31); // Gaido, J.P.

            AgregarHorario(79, 4, 1); // Matemática
            AgregarDetalleHorario(2, DiaEnum.Miércoles, 18);
            AgregarDetalleHorario(2, DiaEnum.Jueves, 16);
            AgregarDetalleHorario(2, DiaEnum.Jueves, 17);
            AgregarDetalleHorario(2, DiaEnum.Jueves, 18);
            AgregarIntegranteHorario(2, 11); // Brussa, G.

            AgregarHorario(80, 3, 1); // Inglés Técnico I
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 15);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 16);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 17);
            AgregarIntegranteHorario(3, 57); // Puccio, D.

            AgregarHorario(81, 3, 1); // Administración
            AgregarDetalleHorario(4, DiaEnum.Lunes, 15);
            AgregarDetalleHorario(4, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(4, DiaEnum.Lunes, 17);
            AgregarIntegranteHorario(4, 47); // Miñoz, A.

            AgregarHorario(82, 4, 1); // Tecnología de la Información
            AgregarDetalleHorario(5, DiaEnum.Jueves, 23);
            AgregarDetalleHorario(5, DiaEnum.Jueves, 25);
            AgregarDetalleHorario(5, DiaEnum.Jueves, 27);
            AgregarDetalleHorario(5, DiaEnum.Jueves, 29);
            AgregarIntegranteHorario(5, 53); // Pedrazzoli, F.

            AgregarHorario(83, 4, 1); // Lógica y Estructura de Datos
            AgregarDetalleHorario(6, DiaEnum.Martes, 21);
            AgregarDetalleHorario(6, DiaEnum.Martes, 23);
            AgregarDetalleHorario(6, DiaEnum.Martes, 25);
            AgregarDetalleHorario(6, DiaEnum.Martes, 27);
            AgregarIntegranteHorario(6, 15); // Calvo, M.

            AgregarHorario(84, 4, 1); // Ingeniería de Software I
            AgregarDetalleHorario(7, DiaEnum.Martes, 15);
            AgregarDetalleHorario(7, DiaEnum.Martes, 16);
            AgregarDetalleHorario(7, DiaEnum.Martes, 17);
            AgregarDetalleHorario(7, DiaEnum.Martes, 18);
            AgregarIntegranteHorario(7, 5); // Alesso, M.

            AgregarHorario(85, 4, 1); // Sistemas Operativos
            AgregarDetalleHorario(8, DiaEnum.Viernes, 21);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 23);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 25);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 27);
            AgregarIntegranteHorario(8, 64); // Sandoval, P.

            AgregarHorario(264, 1, 1); // Recreo
            AgregarDetalleHorario(9, DiaEnum.Lunes, 19);
            AgregarDetalleHorario(9, DiaEnum.Martes, 19);
            AgregarDetalleHorario(9, DiaEnum.Miércoles, 19);
            AgregarDetalleHorario(9, DiaEnum.Jueves, 19);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 19);

            // 2° Año
            AgregarHorario(86, 3, 1); // Problemáticas Socio Contemporáneas
            AgregarDetalleHorario(10, DiaEnum.Lunes, 21);
            AgregarDetalleHorario(10, DiaEnum.Lunes, 23);
            AgregarDetalleHorario(10, DiaEnum.Lunes, 25);
            AgregarIntegranteHorario(10, 22); // Della Rosa, M.

            AgregarHorario(88, 3, 1); // Inglés Técnico II
            AgregarDetalleHorario(11, DiaEnum.Viernes, 21);
            AgregarDetalleHorario(11, DiaEnum.Viernes, 23);
            AgregarDetalleHorario(11, DiaEnum.Viernes, 25);
            AgregarIntegranteHorario(11, 37); // Grosso, S.

            AgregarHorario(89, 3, 1); // Innovación y Desarrollo Emprendedor
            AgregarDetalleHorario(12, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(12, DiaEnum.Lunes, 17);
            AgregarDetalleHorario(12, DiaEnum.Lunes, 18);
            AgregarIntegranteHorario(12, 34); // Gongora, L.

            AgregarHorario(90, 3, 1); // Estadística
            AgregarDetalleHorario(13, DiaEnum.Miércoles, 15);
            AgregarDetalleHorario(13, DiaEnum.Miércoles, 16);
            AgregarDetalleHorario(13, DiaEnum.Miércoles, 17);
            AgregarIntegranteHorario(13, 11); // Brussa, G.

            AgregarHorario(91, 6, 1); // Programación I
            AgregarDetalleHorario(14, DiaEnum.Martes, 15);
            AgregarDetalleHorario(14, DiaEnum.Martes, 16);
            AgregarDetalleHorario(14, DiaEnum.Martes, 17);
            AgregarDetalleHorario(14, DiaEnum.Martes, 18);
            AgregarDetalleHorario(14, DiaEnum.Martes, 21);
            AgregarDetalleHorario(14, DiaEnum.Martes, 23);
            AgregarIntegranteHorario(14, 59); // Ramirez, R.A.

            AgregarHorario(92, 4, 1); // Ingeniería de Software II
            AgregarDetalleHorario(15, DiaEnum.Jueves, 31);
            AgregarDetalleHorario(15, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(15, DiaEnum.Jueves, 36);
            AgregarDetalleHorario(15, DiaEnum.Jueves, 38);
            AgregarIntegranteHorario(15, 4); // Alesso, A.

            AgregarHorario(93, 4, 1); // Base de Datos I
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 18);
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 21);
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 23);
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 25);
            AgregarIntegranteHorario(16, 59); // Ramirez, R.A.

            AgregarHorario(94, 4, 1); // Práctica Profesionalizante I
            AgregarDetalleHorario(17, DiaEnum.Viernes, 15);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 16);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 17);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 18);
            AgregarIntegranteHorario(17, 59); // Ramirez, R.A.

            AgregarHorario(265, 1, 1); // Recreo
            AgregarDetalleHorario(18, DiaEnum.Lunes, 19);
            AgregarDetalleHorario(18, DiaEnum.Martes, 19);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 19);
            AgregarDetalleHorario(18, DiaEnum.Jueves, 19);
            AgregarDetalleHorario(18, DiaEnum.Viernes, 19);

            // 3° Año
            AgregarHorario(95, 3, 1); // Ética y Responsabilidad Social
            AgregarDetalleHorario(19, DiaEnum.Lunes, 15);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 17);
            AgregarIntegranteHorario(19, 75); // Sager, L

            AgregarHorario(96, 3, 1); // Derecho y Legislación Laboral
            AgregarDetalleHorario(20, DiaEnum.Miércoles, 15);
            AgregarDetalleHorario(20, DiaEnum.Miércoles, 16);
            AgregarDetalleHorario(20, DiaEnum.Miércoles, 17);
            AgregarIntegranteHorario(20, 29); // Ferrero, M.

            AgregarHorario(97, 4, 1); // Redes y Comunicación
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 18);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 21);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 23);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 25);
            AgregarIntegranteHorario(21, 5); // Alesso, M.

            AgregarHorario(98, 6, 1); // Programación II
            AgregarDetalleHorario(22, DiaEnum.Jueves, 15);
            AgregarDetalleHorario(22, DiaEnum.Jueves, 16);
            AgregarDetalleHorario(22, DiaEnum.Jueves, 17);
            AgregarDetalleHorario(22, DiaEnum.Jueves, 18);
            AgregarDetalleHorario(22, DiaEnum.Jueves, 21);
            AgregarDetalleHorario(22, DiaEnum.Jueves, 23);
            AgregarIntegranteHorario(22, 59); // Ramirez, R.A.

            AgregarHorario(99, 4, 1); // Gestión de Proyectos de Software
            AgregarDetalleHorario(23, DiaEnum.Lunes, 15);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 17);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 18);
            AgregarIntegranteHorario(23, 59); // Ramirez, R.A.

            AgregarHorario(100, 4, 1); // Base de Datos II
            AgregarDetalleHorario(24, DiaEnum.Lunes, 21);
            AgregarDetalleHorario(24, DiaEnum.Lunes, 23);
            AgregarDetalleHorario(24, DiaEnum.Lunes, 25);
            AgregarDetalleHorario(24, DiaEnum.Lunes, 27);
            AgregarIntegranteHorario(24, 59); // Ramirez, R.A.

            AgregarHorario(101, 6, 1); // Práctica Profesionalizante II
            AgregarDetalleHorario(25, DiaEnum.Martes, 29);
            AgregarDetalleHorario(25, DiaEnum.Martes, 32);
            AgregarDetalleHorario(25, DiaEnum.Martes, 35);
            AgregarDetalleHorario(25, DiaEnum.Martes, 37);
            AgregarDetalleHorario(25, DiaEnum.Martes, 38);
            AgregarDetalleHorario(25, DiaEnum.Martes, 39);
            AgregarIntegranteHorario(25, 4); // Alesso, A.

            AgregarHorario(266, 1, 1); // Recreo
            AgregarDetalleHorario(26, DiaEnum.Lunes, 19);
            AgregarDetalleHorario(26, DiaEnum.Martes, 19);
            AgregarDetalleHorario(26, DiaEnum.Miércoles, 19);
            AgregarDetalleHorario(26, DiaEnum.Jueves, 19);
            AgregarDetalleHorario(26, DiaEnum.Viernes, 19);
            */
            #endregion
            #region enfermeria
            /*
            // 1er año Tecnicatura Superior en Enfermería

            // Salud Pública
            AgregarHorario(103, 3, 1);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 1);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 2);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 3);
            AgregarIntegranteHorario(1, 61); // Rodriguez Quain J.

            // Cuidados de la Enfermería en la Comunidad y Familia
            AgregarHorario(108, 3, 1);
            AgregarDetalleHorario(2, DiaEnum.Martes, 1);
            AgregarDetalleHorario(2, DiaEnum.Martes, 2);
            AgregarDetalleHorario(2, DiaEnum.Martes, 3);
            AgregarIntegranteHorario(2, 3); // Albaristo Stef.

            // Práctica Profesionalizante
            AgregarHorario(109, 8, 1);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 1);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 2);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 3);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 1);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 2);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 3);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 6);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 8);
            AgregarIntegranteHorario(3, 51); // Ortiz L.

            // Fundamentos del Cuidado de Enfermería
            AgregarHorario(107, 4, 1);
            AgregarDetalleHorario(4, DiaEnum.Viernes, 1);
            AgregarDetalleHorario(4, DiaEnum.Viernes, 2);
            AgregarDetalleHorario(4, DiaEnum.Viernes, 3);
            AgregarDetalleHorario(4, DiaEnum.Viernes, 6);
            AgregarIntegranteHorario(4, 3); // Albaristo Stef.

            // Comunicación
            AgregarHorario(102, 3, 1);
            AgregarDetalleHorario(5, DiaEnum.Lunes, 6);
            AgregarDetalleHorario(5, DiaEnum.Lunes, 8);
            AgregarDetalleHorario(5, DiaEnum.Lunes, 10);
            AgregarIntegranteHorario(5, 8); // Blanche C.

            // Sujeto Cultura y Sociedad
            AgregarHorario(105, 3, 1);
            AgregarDetalleHorario(6, DiaEnum.Martes, 6);
            AgregarDetalleHorario(6, DiaEnum.Martes, 8);
            AgregarDetalleHorario(6, DiaEnum.Martes, 10);
            AgregarIntegranteHorario(6, 61); // Rodriguez Quain J.

            // Biología
            AgregarHorario(104, 3, 1);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 8);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 10);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 12);
            AgregarIntegranteHorario(7, 54); // Pereyra S.

            // Recreo
            AgregarHorario(264, 1, 1);
            AgregarDetalleHorario(8, DiaEnum.Lunes, 5);
            AgregarHorario(265, 1, 1);
            AgregarDetalleHorario(9, DiaEnum.Martes, 5);
            AgregarHorario(266, 1, 1);
            AgregarDetalleHorario(10, DiaEnum.Miércoles, 5);
            AgregarHorario(267, 1, 1);
            AgregarDetalleHorario(11, DiaEnum.Jueves, 5);
            AgregarHorario(268, 1, 1);
            AgregarDetalleHorario(12, DiaEnum.Viernes, 5);

            // 2do año Tecnicatura Superior en Enfermería

            // Práctica Profesionalizante II
            AgregarHorario(118, 10, 1);
            AgregarDetalleHorario(13, DiaEnum.Lunes, 1);
            AgregarDetalleHorario(13, DiaEnum.Lunes, 2);
            AgregarDetalleHorario(13, DiaEnum.Lunes, 3);
            AgregarDetalleHorario(13, DiaEnum.Lunes, 6);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 1);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 2);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 3);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 6);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 8);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 10);
            AgregarIntegranteHorario(13, 51); // Ortiz L.

            // Cuidados de Enfermería a Adultos y Adultos Mayores
            AgregarHorario(117, 6, 1);
            AgregarDetalleHorario(14, DiaEnum.Martes, 1);
            AgregarDetalleHorario(14, DiaEnum.Martes, 2);
            AgregarDetalleHorario(14, DiaEnum.Martes, 3);
            AgregarDetalleHorario(14, DiaEnum.Martes, 6);
            AgregarDetalleHorario(14, DiaEnum.Martes, 8);
            AgregarDetalleHorario(14, DiaEnum.Martes, 10);
            AgregarIntegranteHorario(14, 32); // Galmes M.

            // Sujeto Cultura y Sociedad II
            AgregarHorario(113, 3, 1);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 1);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 2);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 3);
            AgregarIntegranteHorario(15, 61); // Rodriguez Quain J.

            // Farmacología
            AgregarHorario(116, 3, 1);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 1);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 2);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 3);
            AgregarIntegranteHorario(16, 9); // Bogni J.

            // Biología II
            AgregarHorario(114, 3, 1);
            AgregarDetalleHorario(17, DiaEnum.Lunes, 8);
            AgregarDetalleHorario(17, DiaEnum.Lunes, 10);
            AgregarDetalleHorario(17, DiaEnum.Lunes, 12);
            AgregarIntegranteHorario(17, 54); // Pereyra S.

            // UDI II
            AgregarHorario(111, 3, 1);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 6);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 8);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 10);
            AgregarIntegranteHorario(18, 49); // Monzón, M.I.

            // Bioseguridad y Medio Ambiente en el Trabajo
            AgregarHorario(115, 3, 1);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 6);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 8);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 10);
            AgregarIntegranteHorario(19, 24); // Doglioli, M.

            // Recreo
            AgregarHorario(269, 1, 1);
            AgregarDetalleHorario(20, DiaEnum.Lunes, 5);
            AgregarHorario(270, 1, 1);
            AgregarDetalleHorario(21, DiaEnum.Martes, 5);
            AgregarHorario(271, 1, 1);
            AgregarDetalleHorario(22, DiaEnum.Miércoles, 5);
            AgregarHorario(272, 1, 1);
            AgregarDetalleHorario(23, DiaEnum.Jueves, 5);
            AgregarHorario(273, 1, 1);
            AgregarDetalleHorario(24, DiaEnum.Viernes, 5);

            // 3er año Tecnicatura Superior en Enfermería

            // Práctica Profesionalizante III
            AgregarHorario(126, 15, 1);
            AgregarDetalleHorario(25, DiaEnum.Lunes, 1);
            AgregarDetalleHorario(25, DiaEnum.Lunes, 2);
            AgregarDetalleHorario(25, DiaEnum.Lunes, 3);
            AgregarDetalleHorario(25, DiaEnum.Lunes, 6);
            AgregarDetalleHorario(25, DiaEnum.Lunes, 8);
            AgregarDetalleHorario(25, DiaEnum.Lunes, 10);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 1);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 2);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 3);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 6);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 8);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 10);
            AgregarIntegranteHorario(25, 32); // Galmes, M.

            // Investigación en Enfermería
            AgregarHorario(123, 3, 1);
            AgregarDetalleHorario(26, DiaEnum.Martes, 1);
            AgregarDetalleHorario(26, DiaEnum.Martes, 2);
            AgregarDetalleHorario(26, DiaEnum.Martes, 3);
            AgregarIntegranteHorario(26, 9); // Bogni J.

            // Cuidados de Niños y Adolescentes
            AgregarHorario(125, 6, 1);
            AgregarDetalleHorario(27, DiaEnum.Miércoles, 1);
            AgregarDetalleHorario(27, DiaEnum.Miércoles, 2);
            AgregarDetalleHorario(27, DiaEnum.Miércoles, 3);
            AgregarDetalleHorario(27, DiaEnum.Martes, 6);
            AgregarDetalleHorario(27, DiaEnum.Martes, 8);
            AgregarDetalleHorario(27, DiaEnum.Martes, 10);
            AgregarIntegranteHorario(27, 3); // Albaristo Stef.

            // Organización y Gestión en Instituciones de Salud
            AgregarHorario(122, 3, 1);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 1);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 2);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 3);
            AgregarIntegranteHorario(28, 25); // Duran

            // Cuidados en Enfermería en Salud Mental
            AgregarHorario(124, 4, 1);
            AgregarDetalleHorario(29, DiaEnum.Miércoles, 6);
            AgregarDetalleHorario(29, DiaEnum.Miércoles, 8);
            AgregarDetalleHorario(29, DiaEnum.Miércoles, 10);
            AgregarDetalleHorario(29, DiaEnum.Miércoles, 12);
            AgregarIntegranteHorario(29, 61); // Rodriguez Quain, J.

            // Derecho y Legislación Laboral
            AgregarHorario(119, 3, 1);
            AgregarDetalleHorario(30, DiaEnum.Jueves, 6);
            AgregarDetalleHorario(30, DiaEnum.Jueves, 8);
            AgregarDetalleHorario(30, DiaEnum.Jueves, 10);
            AgregarIntegranteHorario(30, 30); // Ferr, N.

            // Recreo
            AgregarHorario(274, 1, 1);
            AgregarDetalleHorario(31, DiaEnum.Lunes, 5);
            AgregarHorario(275, 1, 1);
            AgregarDetalleHorario(32, DiaEnum.Martes, 5);
            AgregarHorario(276, 1, 1);
            AgregarDetalleHorario(33, DiaEnum.Miércoles, 5);
            AgregarHorario(277, 1, 1);
            AgregarDetalleHorario(34, DiaEnum.Jueves, 5);
            AgregarHorario(278, 1, 1);
            AgregarDetalleHorario(35, DiaEnum.Viernes, 5);
            */
            #endregion

            #region administración
            /*
            // 1er año del Profesorado de Educación Secundaria en Ciencias de la Administración

            // Sociología
            AgregarHorario(225, 3, 1);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 15);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 17);
            AgregarIntegranteHorario(1, 42); // Mancilla

            // Construcción de Ciudadanía
            AgregarHorario(229, 3, 1);
            AgregarDetalleHorario(2, DiaEnum.Lunes, 18);
            AgregarDetalleHorario(2, DiaEnum.Lunes, 22);
            AgregarDetalleHorario(2, DiaEnum.Lunes, 24);
            AgregarIntegranteHorario(2, 39); // Imperiale

            // Sistema de Información Contable I
            AgregarHorario(228, 4, 1);
            AgregarDetalleHorario(3, DiaEnum.Martes, 15);
            AgregarDetalleHorario(3, DiaEnum.Martes, 16);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 17);
            AgregarDetalleHorario(3, DiaEnum.Jueves, 18);
            AgregarIntegranteHorario(3, 34); // Gongora

            // Pedagogía
            AgregarHorario(224, 3, 1);
            AgregarDetalleHorario(4, DiaEnum.Martes, 17);
            AgregarDetalleHorario(4, DiaEnum.Martes, 18);
            AgregarDetalleHorario(4, DiaEnum.Martes, 22);
            AgregarIntegranteHorario(4, 28); // Ferreyra

            // Matemática
            AgregarHorario(231, 4, 1);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 15);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 16);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 17);
            AgregarDetalleHorario(5, DiaEnum.Jueves, 26);
            AgregarIntegranteHorario(5, 44); // Marenoni

            // Práctica Docente I
            AgregarHorario(232, 3, 1);
            AgregarDetalleHorario(6, DiaEnum.Miércoles, 18);
            AgregarDetalleHorario(6, DiaEnum.Miércoles, 22);
            AgregarDetalleHorario(6, DiaEnum.Miércoles, 24);
            AgregarIntegranteHorario(6, 48); // Molina
            AgregarIntegranteHorario(6, 39); // Imperiale

            // Historia Económica
            AgregarHorario(230, 3, 1);
            AgregarDetalleHorario(7, DiaEnum.Jueves, 15);
            AgregarDetalleHorario(7, DiaEnum.Jueves, 16);
            AgregarDetalleHorario(7, DiaEnum.Viernes, 26);
            AgregarIntegranteHorario(7, 60); // Renteria

            // Administración I
            AgregarHorario(227, 3, 1);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 15);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 16);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 17);
            AgregarIntegranteHorario(8, 17); // Chauderon

            // Administración General
            AgregarHorario(226, 2, 1);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 18);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 22);
            AgregarIntegranteHorario(9, 17); // Chauderon

            // Recreo
            AgregarHorario(276, 1, 1);
            AgregarDetalleHorario(10, DiaEnum.Lunes, 20);
            AgregarDetalleHorario(10, DiaEnum.Martes, 20);
            AgregarDetalleHorario(10, DiaEnum.Miércoles, 20);
            AgregarDetalleHorario(10, DiaEnum.Jueves, 20);
            AgregarDetalleHorario(10, DiaEnum.Viernes, 20);

            // 2do año del Profesorado de Educación Secundaria en Ciencias de la Administración

            // Práctica Docente II
            AgregarHorario(242, 3, 1);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 15);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 17);
            AgregarIntegranteHorario(11, 20); // Dalesio
            AgregarIntegranteHorario(11, 39); // Imperiale

            // Economía
            AgregarHorario(240, 3, 1);
            AgregarDetalleHorario(12, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(12, DiaEnum.Lunes, 27);
            AgregarDetalleHorario(12, DiaEnum.Jueves, 17);
            AgregarIntegranteHorario(12, 60); // Renteria

            // Administración II
            AgregarHorario(236, 3, 1);
            AgregarDetalleHorario(13, DiaEnum.Martes, 16);
            AgregarDetalleHorario(13, DiaEnum.Martes, 17);
            AgregarDetalleHorario(13, DiaEnum.Miércoles, 15);
            AgregarIntegranteHorario(13, 2); // Aimar

            // Estadística Aplicada
            AgregarHorario(241, 4, 1);
            AgregarDetalleHorario(14, DiaEnum.Martes, 18);
            AgregarDetalleHorario(14, DiaEnum.Martes, 22);
            AgregarDetalleHorario(14, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(14, DiaEnum.Miércoles, 27);
            AgregarIntegranteHorario(14, 11); // Brussa

            // Psicología y Educación
            AgregarHorario(235, 3, 1);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 17);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 18);
            AgregarDetalleHorario(15, DiaEnum.Jueves, 15);
            AgregarIntegranteHorario(15, 72); // Vigniatti

            // Didáctica y Curriculum
            AgregarHorario(234, 4, 1);
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 22);
            AgregarDetalleHorario(16, DiaEnum.Miércoles, 24);
            AgregarDetalleHorario(16, DiaEnum.Martes, 24);
            AgregarDetalleHorario(16, DiaEnum.Martes, 26);
            AgregarIntegranteHorario(16, 28); // Ferreyra

            // Derecho I
            AgregarHorario(238, 3, 1);
            AgregarDetalleHorario(17, DiaEnum.Jueves, 22);
            AgregarDetalleHorario(17, DiaEnum.Jueves, 24);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 26);
            AgregarIntegranteHorario(17, 30); // Ferri

            // Sistema de Información Contable II
            AgregarHorario(237, 4, 1);
            AgregarDetalleHorario(18, DiaEnum.Jueves, 18);
            AgregarDetalleHorario(18, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(18, DiaEnum.Jueves, 27);
            AgregarDetalleHorario(18, DiaEnum.Jueves, 28);
            AgregarIntegranteHorario(18, 34); // Gongora

            // Instituciones Educativas
            AgregarHorario(233, 3, 1);
            AgregarDetalleHorario(19, DiaEnum.Viernes, 15);
            AgregarDetalleHorario(19, DiaEnum.Viernes, 16);
            AgregarDetalleHorario(19, DiaEnum.Viernes, 17);
            AgregarIntegranteHorario(19, 49); // Monzon

            // Didáctica de la Administración I
            AgregarHorario(241, 3, 1);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 18);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 22);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 24);
            AgregarIntegranteHorario(20, 18); // Chelini

            // Recreo
            AgregarHorario(277, 1, 1);
            AgregarDetalleHorario(21, DiaEnum.Lunes, 20);
            AgregarDetalleHorario(21, DiaEnum.Martes, 20);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 20);
            AgregarDetalleHorario(21, DiaEnum.Jueves, 20);
            AgregarDetalleHorario(21, DiaEnum.Viernes, 20);

            // 3er año Profesorado de Administración

            // Metodología de la Investigación
            AgregarHorario(23, 3, 1);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 15);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 17);
            AgregarIntegranteHorario(1, 69); // Verzzali, A.

            // Derecho II
            AgregarHorario(25, 4, 1);
            AgregarDetalleHorario(2, DiaEnum.Martes, 15);
            AgregarDetalleHorario(2, DiaEnum.Martes, 16);
            AgregarDetalleHorario(2, DiaEnum.Miércoles, 27);
            AgregarDetalleHorario(2, DiaEnum.Miércoles, 28);
            AgregarIntegranteHorario(2, 30); // Ferr, N.

            // Administración III
            AgregarHorario(246, 4, 1);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 15);
            AgregarDetalleHorario(3, DiaEnum.Miércoles, 16);
            AgregarDetalleHorario(3, DiaEnum.Martes, 27);
            AgregarDetalleHorario(3, DiaEnum.Martes, 28);
            AgregarIntegranteHorario(3, 22); // Della Rosa, M.

            // SIC III
            AgregarHorario(247, 4, 1);
            AgregarDetalleHorario(4, DiaEnum.Jueves, 15);
            AgregarDetalleHorario(4, DiaEnum.Jueves, 16);
            AgregarDetalleHorario(4, DiaEnum.Martes, 17);
            AgregarDetalleHorario(4, DiaEnum.Martes, 18);
            AgregarIntegranteHorario(4, 35); // Gongora, L.

            // Didáctica Específica
            AgregarHorario(250, 3, 1);
            AgregarDetalleHorario(5, DiaEnum.Viernes, 15);
            AgregarDetalleHorario(5, DiaEnum.Viernes, 16);
            AgregarDetalleHorario(5, DiaEnum.Viernes, 17);
            AgregarIntegranteHorario(5, 2); // Aimar, M.A.

            // Historia y Política Educativa
            AgregarHorario(243, 3, 1);
            AgregarDetalleHorario(6, DiaEnum.Lunes, 18);
            AgregarDetalleHorario(6, DiaEnum.Lunes, 21);
            AgregarDetalleHorario(6, DiaEnum.Lunes, 22);
            AgregarIntegranteHorario(6, 28); // Ferreyra, M.

            // Práctica Impositiva y Laboral
            AgregarHorario(248, 3, 1);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 17);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 18);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 21);
            AgregarIntegranteHorario(7, 47); // Miñoz, A.

            // Sujeto de Educación Secundaria
            AgregarHorario(251, 4, 1);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 17);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 18);
            AgregarDetalleHorario(8, DiaEnum.Martes, 21);
            AgregarDetalleHorario(8, DiaEnum.Martes, 22);
            AgregarIntegranteHorario(8, 72); // Vigniatti, E.

            // Filosofía
            AgregarHorario(244, 3, 1);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 18);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 21);
            AgregarDetalleHorario(9, DiaEnum.Viernes, 22);
            AgregarIntegranteHorario(9, 28); // Ferreyra, M.

            // Práctica Docente III
            AgregarHorario(252, 3, 1);
            AgregarDetalleHorario(10, DiaEnum.Jueves, 21);
            AgregarDetalleHorario(10, DiaEnum.Jueves, 22);
            AgregarDetalleHorario(10, DiaEnum.Jueves, 23);
            AgregarIntegranteHorario(10, 74); // Ruiz, A.
            AgregarIntegranteHorario(10, 49); // Monzón, M.I.

            // Producción de Recursos
            AgregarHorario(253, 2, 1);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 23);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 24);
            AgregarIntegranteHorario(11, 48); // Molina, T.

            // Recreo
            AgregarHorario(276, 1, 1);
            AgregarDetalleHorario(12, DiaEnum.Lunes, 19);
            AgregarDetalleHorario(12, DiaEnum.Martes, 19);
            AgregarDetalleHorario(12, DiaEnum.Miércoles, 19);
            AgregarDetalleHorario(12, DiaEnum.Jueves, 19);
            AgregarDetalleHorario(12, DiaEnum.Viernes, 19);

            // 4to año Profesorado de Administración

            // Gestión Organizacional
            AgregarHorario(258, 3, 1);
            AgregarDetalleHorario(13, DiaEnum.Lunes, 15);
            AgregarDetalleHorario(13, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(13, DiaEnum.Lunes, 17);
            AgregarIntegranteHorario(13, 55); // Peressin, S.

            // UDI (Unidad de Definición Institucional)
            AgregarHorario(263, 3, 1);
            AgregarDetalleHorario(14, DiaEnum.Martes, 15);
            AgregarDetalleHorario(14, DiaEnum.Martes, 16);
            AgregarDetalleHorario(14, DiaEnum.Martes, 17);
            AgregarIntegranteHorario(14, 64); // Sandoval, P.

            // Administración IV
            AgregarHorario(257, 3, 1);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 17);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 18);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 21);
            AgregarIntegranteHorario(15, 22); // Della Rosa, M.

            // Comunicación Social
            AgregarHorario(256, 3, 1);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 16);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 17);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 18);
            AgregarIntegranteHorario(16, 31); // Gaido, J.P.

            // ESI (Educación Sexual Integral)
            AgregarHorario(255, 3, 1);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 15);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 16);
            AgregarDetalleHorario(17, DiaEnum.Viernes, 17);
            AgregarIntegranteHorario(17, 69); // Verzzali, A.

            // Matemática Financiera
            AgregarHorario(259, 3, 1);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 18);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 21);
            AgregarDetalleHorario(18, DiaEnum.Lunes, 22);
            AgregarIntegranteHorario(18, 48); // Molina, T.

            // Producción de Recursos II
            AgregarHorario(262, 3, 1);
            AgregarDetalleHorario(19, DiaEnum.Martes, 18);
            AgregarDetalleHorario(19, DiaEnum.Martes, 21);
            AgregarDetalleHorario(19, DiaEnum.Martes, 22);
            AgregarIntegranteHorario(19, 22); // Della Rosa, M.

            // Ética y Trabajo Docente
            AgregarHorario(254, 3, 1);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 18);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 21);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 22);
            AgregarIntegranteHorario(20, 40); // Lodi, L.

            // Práctica Docente IV
            AgregarHorario(261, 3, 1);
            AgregarDetalleHorario(21, DiaEnum.Jueves, 21);
            AgregarDetalleHorario(21, DiaEnum.Jueves, 22);
            AgregarDetalleHorario(21, DiaEnum.Jueves, 23);
            AgregarIntegranteHorario(21, 27); // Espru, F.
            AgregarIntegranteHorario(21, 60); // Renteria, D.

            // Práctica de Investigación
            AgregarHorario(260, 3, 1);
            AgregarDetalleHorario(22, DiaEnum.Miércoles, 22);
            AgregarDetalleHorario(22, DiaEnum.Miércoles, 23);
            AgregarDetalleHorario(22, DiaEnum.Miércoles, 24);
            AgregarIntegranteHorario(22, 36); // Gretter, M.C.
            AgregarIntegranteHorario(22, 74); // Ruiz, A.

            // Recreo
            AgregarHorario(277, 1, 1);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 19);
            AgregarDetalleHorario(23, DiaEnum.Martes, 19);
            AgregarDetalleHorario(23, DiaEnum.Miércoles, 19);
            AgregarDetalleHorario(23, DiaEnum.Jueves, 19);
            AgregarDetalleHorario(23, DiaEnum.Viernes, 19);
            */
            #endregion
            #region economía
            /*
            // Horarios
            AgregarHorario(9, 3, 1);  // Matemática
            AgregarHorario(1, 3, 1);  // Pedagogía
            AgregarHorario(3, 4, 1);  // Administración General
            AgregarHorario(4, 4, 1);  // Economía I
            AgregarHorario(5, 4, 1);  // Geografía Económica
            AgregarHorario(6, 4, 1);  // Historia Económica
            AgregarHorario(7, 3, 1);  // Construcción de Ciudadanía
            AgregarHorario(8, 4, 1);  // Sistema de Información Contable I
            AgregarHorario(2, 3, 1);  // UCCV Sociología
            AgregarHorario(10, 3, 1); // Práctica Docente I
            AgregarHorario(264, 1, 1); // Recreo

            AgregarHorario(11, 3, 1);  // Instituciones Educativas
            AgregarHorario(12, 3, 1);  // Didáctica y Curriculum
            AgregarHorario(13, 4, 1);  // Psicología y Educación
            AgregarHorario(14, 4, 1);  // Economía II
            AgregarHorario(15, 4, 1);  // Sistema de Información Contable II
            AgregarHorario(16, 3, 1);  // Derecho I
            AgregarHorario(17, 4, 1);  // Estadística Aplicada
            AgregarHorario(18, 3, 1);  // Didáctica de la Economía I
            AgregarHorario(19, 3, 1);  // Práctica Docente II
            AgregarHorario(265, 1, 1); // Recreo

            // Detalles de Horario para 1er año
            AgregarDetalleHorario(1, DiaEnum.Lunes, 1);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 2);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 3);
            AgregarDetalleHorario(2, DiaEnum.Martes, 2);
            AgregarDetalleHorario(2, DiaEnum.Martes, 3);
            AgregarDetalleHorario(2, DiaEnum.Martes, 4);
            AgregarDetalleHorario(3, DiaEnum.Lunes, 12);
            AgregarDetalleHorario(3, DiaEnum.Lunes, 13);
            AgregarDetalleHorario(3, DiaEnum.Martes, 12);
            AgregarDetalleHorario(3, DiaEnum.Martes, 13);
            AgregarDetalleHorario(4, DiaEnum.Martes, 10);
            AgregarDetalleHorario(4, DiaEnum.Martes, 11);
            AgregarDetalleHorario(4, DiaEnum.Miércoles, 12);
            AgregarDetalleHorario(4, DiaEnum.Miércoles, 13);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 1);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 2);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 3);
            AgregarDetalleHorario(5, DiaEnum.Miércoles, 4);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 3);
            AgregarDetalleHorario(6, DiaEnum.Jueves, 4);
            AgregarDetalleHorario(6, DiaEnum.Viernes, 12);
            AgregarDetalleHorario(6, DiaEnum.Viernes, 13);
            AgregarDetalleHorario(7, DiaEnum.Viernes, 1);
            AgregarDetalleHorario(7, DiaEnum.Viernes, 2);
            AgregarDetalleHorario(7, DiaEnum.Viernes, 3);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 1);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 2);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 10);
            AgregarDetalleHorario(8, DiaEnum.Viernes, 11);
            AgregarDetalleHorario(9, DiaEnum.Lunes, 4);
            AgregarDetalleHorario(9, DiaEnum.Lunes, 10);
            AgregarDetalleHorario(9, DiaEnum.Lunes, 11);
            AgregarDetalleHorario(10, DiaEnum.Jueves, 10);
            AgregarDetalleHorario(10, DiaEnum.Jueves, 11);
            AgregarDetalleHorario(10, DiaEnum.Jueves, 12);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 7);
            AgregarDetalleHorario(11, DiaEnum.Martes, 7);
            AgregarDetalleHorario(11, DiaEnum.Miércoles, 7);
            AgregarDetalleHorario(11, DiaEnum.Jueves, 7);
            AgregarDetalleHorario(11, DiaEnum.Viernes, 7);

            // Detalles de Horario para 2do año
            AgregarDetalleHorario(12, DiaEnum.Viernes, 10);
            AgregarDetalleHorario(12, DiaEnum.Viernes, 11);
            AgregarDetalleHorario(12, DiaEnum.Viernes, 12);
            AgregarDetalleHorario(13, DiaEnum.Martes, 11);
            AgregarDetalleHorario(13, DiaEnum.Martes, 12);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 1);
            AgregarDetalleHorario(14, DiaEnum.Martes, 1);
            AgregarDetalleHorario(14, DiaEnum.Martes, 2);
            AgregarDetalleHorario(14, DiaEnum.Viernes, 3);
            AgregarDetalleHorario(14, DiaEnum.Viernes, 4);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 1);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 2);
            AgregarDetalleHorario(15, DiaEnum.Jueves, 1);
            AgregarDetalleHorario(15, DiaEnum.Jueves, 2);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 10);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 11);
            AgregarDetalleHorario(16, DiaEnum.Jueves, 12);
            AgregarDetalleHorario(17, DiaEnum.Martes, 3);
            AgregarDetalleHorario(17, DiaEnum.Martes, 4);
            AgregarDetalleHorario(17, DiaEnum.Lunes, 10);
            AgregarDetalleHorario(17, DiaEnum.Lunes, 11);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 3);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 4);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 10);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 1);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 2);
            AgregarDetalleHorario(19, DiaEnum.Lunes, 3);
            AgregarDetalleHorario(20, DiaEnum.Lunes, 7);
            AgregarDetalleHorario(20, DiaEnum.Martes, 7);
            AgregarDetalleHorario(20, DiaEnum.Miércoles, 7);
            AgregarDetalleHorario(20, DiaEnum.Jueves, 7);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 7);

            // Integrantes de Horario para 1er año
            AgregarIntegranteHorario(1, 44);  // Marenoni, A.
            AgregarIntegranteHorario(2, 28);  // Ferreyra, M.
            AgregarIntegranteHorario(3, 17);  // Chauderón, L.
            AgregarIntegranteHorario(4, 12);  // Buceta, MB.
            AgregarIntegranteHorario(5, 35);  // Gomez, V.
            AgregarIntegranteHorario(6, 60);  // Renteria, D.
            AgregarIntegranteHorario(7, 71);  // Verzzali, A.
            AgregarIntegranteHorario(8, 2);   // Aimar, M.A.
            AgregarIntegranteHorario(9, 42);  // Mancilla, J.
            AgregarIntegranteHorario(10, 12); // Buceta, MB.
            AgregarIntegranteHorario(10, 39); // Imperiale, M.

            // Integrantes de Horario para 2do año
            AgregarIntegranteHorario(12, 27);  // Espru, F.
            AgregarIntegranteHorario(13, 28);  // Ferreyra, M.
            AgregarIntegranteHorario(14, 13);  // Bueno, M.F.
            AgregarIntegranteHorario(15, 12);  // Buceta, MB.
            AgregarIntegranteHorario(16, 2);   // Aimar, M.A.
            AgregarIntegranteHorario(17, 30);  // Ferr, N.
            AgregarIntegranteHorario(18, 11);  // Brussa, G.
            AgregarIntegranteHorario(19, 14);  // Cainero, G.
            AgregarIntegranteHorario(20, 12);  // Buceta, MB.
            AgregarIntegranteHorario(20, 71);  // Verzzali, A.
                                               // Horarios para 3er año
            AgregarHorario(22, 3, 1);  // Metodología de la Investigación
            AgregarHorario(25, 3, 1);  // Derecho II
            AgregarHorario(21, 3, 1);  // Filosofía
            AgregarHorario(28, 2, 1);  // Producción de los Recursos Didácticos I
            AgregarHorario(26, 3, 1);  // Sujetos de la Educación Secundaria
            AgregarHorario(23, 4, 1);  // Economía III
            AgregarHorario(24, 3, 1);  // Finanzas Públicas
            AgregarHorario(20, 3, 1);  // Historia y Política de la Educación Argentina
            AgregarHorario(27, 3, 1);  // Práctica Docente III
            AgregarHorario(266, 1, 1); // Recreo

            // Horarios para 4to año
            AgregarHorario(34, 3, 1);  // Prácticas de Investigación
            AgregarHorario(33, 4, 1);  // Economía Argentina Latinoamericana e Internacional
            AgregarHorario(31, 3, 1);  // UCCV Comunicación Social
            AgregarHorario(37, 3, 1);  // Unidad de Definición Institucional
            AgregarHorario(32, 3, 1);  // Economía Social y Sostenible
            AgregarHorario(30, 3, 1);  // Educación Sexual Integral
            AgregarHorario(36, 3, 1);  // Producción de los Recursos Didácticos II
            AgregarHorario(35, 3, 1);  // Práctica Docente IV (Residencia)
            AgregarHorario(29, 3, 1);  // Ética y Trabajo Docente
            AgregarHorario(267, 1, 1); // Recreo

            // Detalles de Horario para 3er año
            AgregarDetalleHorario(21, DiaEnum.Lunes, 1);
            AgregarDetalleHorario(21, DiaEnum.Lunes, 2);
            AgregarDetalleHorario(21, DiaEnum.Lunes, 3);
            AgregarDetalleHorario(22, DiaEnum.Martes, 1);
            AgregarDetalleHorario(22, DiaEnum.Martes, 2);
            AgregarDetalleHorario(23, DiaEnum.Miércoles, 1);
            AgregarDetalleHorario(23, DiaEnum.Miércoles, 2);
            AgregarDetalleHorario(23, DiaEnum.Miércoles, 3);
            AgregarDetalleHorario(24, DiaEnum.Jueves, 1);
            AgregarDetalleHorario(24, DiaEnum.Jueves, 2);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 1);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 2);
            AgregarDetalleHorario(25, DiaEnum.Viernes, 3);
            AgregarDetalleHorario(26, DiaEnum.Martes, 11);
            AgregarDetalleHorario(26, DiaEnum.Martes, 12);
            AgregarDetalleHorario(26, DiaEnum.Miércoles, 12);
            AgregarDetalleHorario(26, DiaEnum.Miércoles, 13);
            AgregarDetalleHorario(27, DiaEnum.Miércoles, 4);
            AgregarDetalleHorario(27, DiaEnum.Miércoles, 10);
            AgregarDetalleHorario(27, DiaEnum.Miércoles, 11);
            AgregarDetalleHorario(27, DiaEnum.Jueves, 10);
            AgregarDetalleHorario(27, DiaEnum.Jueves, 11);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 3);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 4);
            AgregarDetalleHorario(29, DiaEnum.Jueves, 12);
            AgregarDetalleHorario(29, DiaEnum.Jueves, 13);
            AgregarDetalleHorario(29, DiaEnum.Viernes, 10);
            AgregarDetalleHorario(30, DiaEnum.Lunes, 7);
            AgregarDetalleHorario(30, DiaEnum.Martes, 7);
            AgregarDetalleHorario(30, DiaEnum.Miércoles, 7);
            AgregarDetalleHorario(30, DiaEnum.Jueves, 7);
            AgregarDetalleHorario(30, DiaEnum.Viernes, 7);

            // Detalles de Horario para 4to año
            AgregarDetalleHorario(31, DiaEnum.Lunes, 1);
            AgregarDetalleHorario(31, DiaEnum.Lunes, 2);
            AgregarDetalleHorario(31, DiaEnum.Lunes, 3);
            AgregarDetalleHorario(32, DiaEnum.Martes, 1);
            AgregarDetalleHorario(32, DiaEnum.Martes, 2);
            AgregarDetalleHorario(32, DiaEnum.Martes, 3);
            AgregarDetalleHorario(32, DiaEnum.Martes, 4);
            AgregarDetalleHorario(33, DiaEnum.Miércoles, 1);
            AgregarDetalleHorario(33, DiaEnum.Miércoles, 2);
            AgregarDetalleHorario(33, DiaEnum.Miércoles, 3);
            AgregarDetalleHorario(34, DiaEnum.Jueves, 1);
            AgregarDetalleHorario(34, DiaEnum.Jueves, 2);
            AgregarDetalleHorario(34, DiaEnum.Jueves, 3);
            AgregarDetalleHorario(35, DiaEnum.Viernes, 2);
            AgregarDetalleHorario(35, DiaEnum.Viernes, 3);
            AgregarDetalleHorario(35, DiaEnum.Viernes, 4);
            AgregarDetalleHorario(36, DiaEnum.Miércoles, 4);
            AgregarDetalleHorario(36, DiaEnum.Miércoles, 10);
            AgregarDetalleHorario(36, DiaEnum.Miércoles, 11);
            AgregarDetalleHorario(37, DiaEnum.Jueves, 10);
            AgregarDetalleHorario(37, DiaEnum.Jueves, 11);
            AgregarDetalleHorario(37, DiaEnum.Jueves, 12);
            AgregarDetalleHorario(38, DiaEnum.Viernes, 10);
            AgregarDetalleHorario(38, DiaEnum.Viernes, 11);
            AgregarDetalleHorario(38, DiaEnum.Viernes, 12);
            AgregarDetalleHorario(39, DiaEnum.Lunes, 10);
            AgregarDetalleHorario(39, DiaEnum.Lunes, 11);
            AgregarDetalleHorario(39, DiaEnum.Lunes, 12);
            AgregarDetalleHorario(40, DiaEnum.Lunes, 7);
            AgregarDetalleHorario(40, DiaEnum.Martes, 7);
            AgregarDetalleHorario(40, DiaEnum.Miércoles, 7);
            AgregarDetalleHorario(40, DiaEnum.Jueves, 7);
            AgregarDetalleHorario(40, DiaEnum.Viernes, 7);

            // Integrantes de Horario para 3er año
            AgregarIntegranteHorario(21, 39); // Imperiale, M.
            AgregarIntegranteHorario(22, 30); // Ferr, N.
            AgregarIntegranteHorario(23, 39); // Imperiale, M.
            AgregarIntegranteHorario(24, 60); // Renteria, D.
            AgregarIntegranteHorario(25, 72); // Vigniatti, E.
            AgregarIntegranteHorario(26, 14); // Cainero, G.
            AgregarIntegranteHorario(27, 62); // Rosso, E.
            AgregarIntegranteHorario(28, 27); // Espru, F.
            AgregarIntegranteHorario(29, 14); // Cainero, G.
            AgregarIntegranteHorario(29, 71); // Verzzali, A.

            // Integrantes de Horario para 4to año
            AgregarIntegranteHorario(31, 36); // Gretter, M.C.
            AgregarIntegranteHorario(31, 22); // Della Rosa, M.
            AgregarIntegranteHorario(32, 2);  // Aimar, M.A.
            AgregarIntegranteHorario(33, 31); // Gaido, J.P.
            AgregarIntegranteHorario(34, 64); // Sandoval, P.
            AgregarIntegranteHorario(35, 74); // Ruiz, A.
            AgregarIntegranteHorario(36, 71); // Verzzali, A.
            AgregarIntegranteHorario(37, 22); // Della Rosa, M.
            AgregarIntegranteHorario(38, 27); // Espru, F.
            AgregarIntegranteHorario(38, 60); // Renteria, D.
            AgregarIntegranteHorario(39, 39); // Imperiale, M.
            */
            #endregion
            #region inicial
            /*
            // 1er año - Profesorado de Educación Inicial

            // Taller de Práctica I
            AgregarHorario(186, 3, 1);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 9);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 11);
            AgregarDetalleHorario(1, DiaEnum.Lunes, 13);
            AgregarIntegranteHorario(1, 72); // Vignatti, E.

            // Comunicación y Expresión Oral y Escrita
            AgregarHorario(188, 3, 1);
            AgregarDetalleHorario(2, DiaEnum.Lunes, 15);
            AgregarDetalleHorario(2, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(2, DiaEnum.Lunes, 17);
            AgregarIntegranteHorario(2, 31); // Gaido, J.P.

            // Historia Argentina y Latinoamericana - Ambiente y Sociedad
            AgregarHorario(182, 3, 1);
            AgregarDetalleHorario(3, DiaEnum.Lunes, 18);
            AgregarDetalleHorario(3, DiaEnum.Lunes, 21);
            AgregarDetalleHorario(3, DiaEnum.Lunes, 23);
            AgregarIntegranteHorario(3, 42); // Mancilla, J.
            AgregarIntegranteHorario(3, 54); // Pereyra, S.

            // Psicología y Educación
            AgregarHorario(179, 3, 1);
            AgregarDetalleHorario(4, DiaEnum.Martes, 15);
            AgregarDetalleHorario(4, DiaEnum.Martes, 16);
            AgregarDetalleHorario(4, DiaEnum.Viernes, 17);
            AgregarDetalleHorario(4, DiaEnum.Viernes, 18);
            AgregarIntegranteHorario(4, 10); // Brondino, D.

            // Movimiento y Cuerpo
            AgregarHorario(183, 3, 1);
            AgregarDetalleHorario(5, DiaEnum.Martes, 17);
            AgregarDetalleHorario(5, DiaEnum.Martes, 18);
            AgregarDetalleHorario(5, DiaEnum.Viernes, 15);
            AgregarDetalleHorario(5, DiaEnum.Viernes, 16);
            AgregarIntegranteHorario(5, 65); // Sancho, I.

            // Área Estético-Expresiva
            AgregarHorario(189, 3, 1);
            AgregarDetalleHorario(6, DiaEnum.Martes, 21);
            AgregarDetalleHorario(6, DiaEnum.Martes, 23);
            AgregarDetalleHorario(6, DiaEnum.Martes, 25);
            AgregarIntegranteHorario(6, 68); // Tovar, C.
            AgregarIntegranteHorario(6, 65); // Sancho, I.
            AgregarIntegranteHorario(6, 19); // Corradi, R.

            // Pedagogía
            AgregarHorario(180, 4, 1);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 15);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 16);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 17);
            AgregarDetalleHorario(7, DiaEnum.Miércoles, 18);
            AgregarIntegranteHorario(7, 49); // Monzón, M.I.

            // Problemática Contemporánea de la Educación Inicial I
            AgregarHorario(185, 3, 1);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 15);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 16);
            AgregarDetalleHorario(8, DiaEnum.Jueves, 17);
            AgregarIntegranteHorario(8, 43); // Manattini, S.

            // Resolución de Problemas y Creatividad
            AgregarHorario(187, 3, 1);
            AgregarDetalleHorario(9, DiaEnum.Jueves, 18);
            AgregarDetalleHorario(9, DiaEnum.Jueves, 21);
            AgregarDetalleHorario(9, DiaEnum.Jueves, 23);
            AgregarIntegranteHorario(9, 36); // Gretter, M.C.

            // Sociología de la Educación
            AgregarHorario(181, 2, 1);
            AgregarDetalleHorario(10, DiaEnum.Viernes, 21);
            AgregarDetalleHorario(10, DiaEnum.Viernes, 23);
            AgregarIntegranteHorario(10, 73); // Villa, M.F.

            // Recreo
            AgregarHorario(264, 1, 1);
            AgregarDetalleHorario(11, DiaEnum.Lunes, 19);
            AgregarDetalleHorario(11, DiaEnum.Martes, 19);
            AgregarDetalleHorario(11, DiaEnum.Miércoles, 19);
            AgregarDetalleHorario(11, DiaEnum.Jueves, 19);
            AgregarDetalleHorario(11, DiaEnum.Viernes, 19);

            // 2do año - Profesorado de Educación Inicial

            // Taller de Práctica II
            AgregarHorario(196, 4, 1);
            AgregarDetalleHorario(12, DiaEnum.Martes, 15);
            AgregarDetalleHorario(12, DiaEnum.Martes, 16);
            AgregarDetalleHorario(12, DiaEnum.Martes, 17);
            AgregarDetalleHorario(12, DiaEnum.Martes, 18);
            AgregarIntegranteHorario(12, 72); // Vignatti, E.

            // Didáctica de la Educación Inicial I
            AgregarHorario(198, 3, 1);
            AgregarDetalleHorario(13, DiaEnum.Jueves, 15);
            AgregarDetalleHorario(13, DiaEnum.Jueves, 16);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 17);
            AgregarDetalleHorario(13, DiaEnum.Viernes, 18);
            AgregarIntegranteHorario(13, 49); // Monzón, M.I.

            // Ciencias Naturales y su Didáctica
            AgregarHorario(201, 4, 1);
            AgregarDetalleHorario(14, DiaEnum.Lunes, 16);
            AgregarDetalleHorario(14, DiaEnum.Lunes, 17);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 21);
            AgregarDetalleHorario(14, DiaEnum.Jueves, 23);
            AgregarIntegranteHorario(14, 54); // Pereyra, S.

            // Literatura y su Didáctica
            AgregarHorario(200, 4, 1);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 16);
            AgregarDetalleHorario(15, DiaEnum.Miércoles, 17);
            AgregarDetalleHorario(15, DiaEnum.Martes, 23);
            AgregarDetalleHorario(15, DiaEnum.Martes, 27);
            AgregarIntegranteHorario(15, 69); // Tregnaghi, C.

            // Didáctica General
            AgregarHorario(192, 3, 1);
            AgregarDetalleHorario(16, DiaEnum.Lunes, 18);
            AgregarDetalleHorario(16, DiaEnum.Lunes, 21);
            AgregarDetalleHorario(16, DiaEnum.Viernes, 16);
            AgregarDetalleHorario(16, DiaEnum.Viernes, 17);
            AgregarIntegranteHorario(16, 40); // Lodi, L.

            // Sujeto de la Educación Inicial
            AgregarHorario(197, 3, 1);
            AgregarDetalleHorario(17, DiaEnum.Lunes, 23);
            AgregarDetalleHorario(17, DiaEnum.Lunes, 25);
            AgregarDetalleHorario(17, DiaEnum.Martes, 21);
            AgregarDetalleHorario(17, DiaEnum.Martes, 23);
            AgregarIntegranteHorario(17, 40); // Lodi, L.

            // Matemática y su Didáctica
            AgregarHorario(199, 3, 1);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 18);
            AgregarDetalleHorario(18, DiaEnum.Miércoles, 21);
            AgregarDetalleHorario(18, DiaEnum.Jueves, 17);
            AgregarDetalleHorario(18, DiaEnum.Jueves, 18);
            AgregarIntegranteHorario(18, 44); // Marenoni, A.

            // Movimiento y Cuerpo II
            AgregarHorario(195, 4, 1);
            AgregarDetalleHorario(19, DiaEnum.Miércoles, 23);
            AgregarDetalleHorario(19, DiaEnum.Miércoles, 25);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 25);
            AgregarDetalleHorario(19, DiaEnum.Jueves, 27);
            AgregarIntegranteHorario(19, 65); // Sancho, I.

            // Filosofía de la Educación
            AgregarHorario(193, 3, 1);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 23);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 25);
            AgregarDetalleHorario(20, DiaEnum.Viernes, 27);
            AgregarIntegranteHorario(20, 28); // Ferreyra, M.

            // Recreo
            AgregarHorario(265, 1, 1);
            AgregarDetalleHorario(21, DiaEnum.Lunes, 19);
            AgregarDetalleHorario(21, DiaEnum.Martes, 19);
            AgregarDetalleHorario(21, DiaEnum.Miércoles, 19);
            AgregarDetalleHorario(21, DiaEnum.Jueves, 19);
            AgregarDetalleHorario(21, DiaEnum.Viernes, 19);

            // 3er año - Profesorado de Educación Inicial

            // Tecnologías de la Información y de la Comunicación
            AgregarHorario(204, 3, 1);
            AgregarDetalleHorario(22, DiaEnum.Miércoles, 34);
            AgregarDetalleHorario(22, DiaEnum.Miércoles, 36);
            AgregarDetalleHorario(22, DiaEnum.Miércoles, 38);
            AgregarIntegranteHorario(22, 21); // Degiorgio, O.

            // Taller de Práctica III
            AgregarHorario(206, 4, 1);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 24);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(23, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(23, DiaEnum.Martes, 24);
            AgregarDetalleHorario(23, DiaEnum.Martes, 26);
            AgregarDetalleHorario(23, DiaEnum.Martes, 28);
            AgregarIntegranteHorario(23, 73); // Villa, M.F.
            AgregarIntegranteHorario(23, 52); // Paredes, M.

            // Matemática y su Didáctica II
            AgregarHorario(207, 3, 1);
            AgregarDetalleHorario(24, DiaEnum.Miércoles, 24);
            AgregarDetalleHorario(24, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(24, DiaEnum.Miércoles, 28);
            AgregarIntegranteHorario(24, 44); // Marenoni, A.

            // Lengua y su Didáctica
            AgregarHorario(208, 3, 1);
            AgregarDetalleHorario(25, DiaEnum.Jueves, 22);
            AgregarDetalleHorario(25, DiaEnum.Jueves, 24);
            AgregarDetalleHorario(25, DiaEnum.Martes, 34);
            AgregarDetalleHorario(25, DiaEnum.Martes, 36);
            AgregarIntegranteHorario(25, 69); // Tregnaghi, C.

            // Historia Social de la Educación y Política Educativa Argentina
            AgregarHorario(205, 3, 1);
            AgregarDetalleHorario(26, DiaEnum.Jueves, 26);
            AgregarDetalleHorario(26, DiaEnum.Jueves, 28);
            AgregarDetalleHorario(26, DiaEnum.Jueves, 30);
            AgregarIntegranteHorario(26, 28); // Ferreyra, M.

            // Ciencias Sociales y su Didáctica
            AgregarHorario(210, 4, 1);
            AgregarDetalleHorario(27, DiaEnum.Lunes, 30);
            AgregarDetalleHorario(27, DiaEnum.Lunes, 34);
            AgregarDetalleHorario(27, DiaEnum.Jueves, 36);
            AgregarDetalleHorario(27, DiaEnum.Jueves, 38);
            AgregarIntegranteHorario(27, 42); // Mancilla, J.

            // Área Estético-Expresiva II
            AgregarHorario(211, 3, 1);
            AgregarDetalleHorario(28, DiaEnum.Miércoles, 30);
            AgregarDetalleHorario(28, DiaEnum.Miércoles, 31);
            AgregarDetalleHorario(28, DiaEnum.Jueves, 31);
            AgregarDetalleHorario(28, DiaEnum.Viernes, 31);
            AgregarIntegranteHorario(28, 68); // Tovar, C.
            AgregarIntegranteHorario(28, 65); // Sancho, I.
            AgregarIntegranteHorario(28, 19); // Corradi, R.

            // Didáctica de la Educación Inicial II
            AgregarHorario(213, 2, 1);
            AgregarDetalleHorario(29, DiaEnum.Martes, 28);
            AgregarDetalleHorario(29, DiaEnum.Martes, 30);
            AgregarDetalleHorario(29, DiaEnum.Viernes, 24);
            AgregarDetalleHorario(29, DiaEnum.Viernes, 26);
            AgregarIntegranteHorario(29, 72); // Vigniatti, E.
            AgregarIntegranteHorario(29, 41); // Lovino, F.

            // Espacios de Definición Institucional
            AgregarHorario(214, 2, 1);
            AgregarDetalleHorario(30, DiaEnum.Viernes, 28);
            AgregarDetalleHorario(30, DiaEnum.Viernes, 30);
            AgregarIntegranteHorario(30, 70); // Tschopp, M.R.

            // Recreo
            AgregarHorario(266, 1, 1);
            AgregarDetalleHorario(31, DiaEnum.Lunes, 33);
            AgregarDetalleHorario(31, DiaEnum.Martes, 33);
            AgregarDetalleHorario(31, DiaEnum.Miércoles, 33);
            AgregarDetalleHorario(31, DiaEnum.Jueves, 33);
            AgregarDetalleHorario(31, DiaEnum.Viernes, 33);

            // 4to año - Profesorado de Educación Inicial

            // Ética, Trabajo Docente, Derechos Humanos y Ciudadanía
            AgregarHorario(218, 3, 1);
            AgregarDetalleHorario(32, DiaEnum.Miércoles, 26);
            AgregarDetalleHorario(32, DiaEnum.Miércoles, 28);
            AgregarDetalleHorario(32, DiaEnum.Miércoles, 30);
            AgregarIntegranteHorario(32, 28); // Ferreyra, M.

            // Taller de Práctica IV y Ateneo
            AgregarHorario(219, 6, 1);
            AgregarDetalleHorario(33, DiaEnum.Martes, 28);
            AgregarDetalleHorario(33, DiaEnum.Martes, 30);
            AgregarDetalleHorario(33, DiaEnum.Jueves, 28);
            AgregarDetalleHorario(33, DiaEnum.Jueves, 30);
            AgregarDetalleHorario(33, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(33, DiaEnum.Jueves, 36);
            AgregarIntegranteHorario(33, 50); // Nasimbera, R.
            AgregarIntegranteHorario(33, 52); // Paredes, M.

            // Ateneo: (Matemática- Ambiente y Sociedad (Ciencias Naturales y Ciencias Sociales)- Lengua y Literatura- Corporeidad)
            AgregarHorario(220, 6, 1);
            AgregarDetalleHorario(34, DiaEnum.Jueves, 28);
            AgregarDetalleHorario(34, DiaEnum.Jueves, 30);
            AgregarDetalleHorario(34, DiaEnum.Jueves, 34);
            AgregarDetalleHorario(34, DiaEnum.Jueves, 36);
            AgregarIntegranteHorario(34, 54); // Pereyra, S.
            AgregarIntegranteHorario(34, 11); // Brussa, G.
            AgregarIntegranteHorario(34, 42); // Mancilla, J.
            AgregarIntegranteHorario(34, 69); // Tregnaghi, C.

            // Sexualidad Humana y Educación
            AgregarHorario(221, 4, 1);
            AgregarDetalleHorario(35, DiaEnum.Lunes, 26);
            AgregarDetalleHorario(35, DiaEnum.Lunes, 28);
            AgregarDetalleHorario(35, DiaEnum.Lunes, 30);
            AgregarDetalleHorario(35, DiaEnum.Lunes, 34);
            AgregarIntegranteHorario(35, 54); // Pereyra, S.

            // Recreo
            AgregarHorario(267, 1, 1);
            AgregarDetalleHorario(36, DiaEnum.Lunes, 33);
            AgregarDetalleHorario(36, DiaEnum.Martes, 33);
            AgregarDetalleHorario(36, DiaEnum.Miércoles, 33);
            AgregarDetalleHorario(36, DiaEnum.Jueves, 33);
            */
            #endregion
            modelBuilder.Entity<Horario>().HasData(horarios);
            modelBuilder.Entity<DetalleHorario>().HasData(detallesHorario);
            modelBuilder.Entity<IntegranteHorario>().HasData(integrantesHorario);
            
            #region datos semillas InscriptoCarrera
            var inscriptoCarrera = new InscriptoCarrera { Id = 1, AlumnoId = 1, CarreraId = 1 };

            modelBuilder.Entity<InscriptoCarrera>().HasData(inscriptoCarrera);
            #endregion
            #region datos semillas Usuarios
            var usuario = new Usuario { Id = 1, User = "admin", Email = "admin@gmail.com", TipoUsuario = TipoUsuarioEnum.Directivo, DocenteId = 1 };

            modelBuilder.Entity<Usuario>().HasData(usuario);
            #endregion
        }

        public virtual DbSet<Alumno> alumnos { get; set; }
        public virtual DbSet<Carrera> carreras { get; set; }
        public virtual DbSet<Inscripcion> inscripciones { get; set; }
        public virtual DbSet<AnioCarrera> anioscarreras { get; set; }
        public virtual DbSet<Materia> materias { get; set; }
        public virtual DbSet<DetalleInscripcion> detallesinscripciones { get; set; }
        public virtual DbSet<TurnoExamen> turnosexamenes { get; set; }
        public virtual DbSet<CicloLectivo> cicloslectivos { get; set; }
        public virtual DbSet<Docente> docentes { get; set; }
        public virtual DbSet<MesaExamen> mesasexamenes { get; set; }
        public virtual DbSet<DetalleMesaExamen> detallesmesasexamenes { get; set; }
        public virtual DbSet<Horario> horarios { get; set; }
        public virtual DbSet<DetalleHorario> detalleshorarios { get; set; }
        public virtual DbSet<IntegranteHorario> integranteshorarios { get; set; }
        public virtual DbSet<Hora> horas { get; set; }
        public virtual DbSet<InscriptoCarrera> inscriptoscarreras { get; set; }
        public virtual DbSet<Usuario> usuarios { get; set; }


    }
}
