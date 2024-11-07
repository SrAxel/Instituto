using InstitutoDesktop.Views.Commons;
using Microsoft.Extensions.DependencyInjection;
using InstitutoServices.Services.Commons;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons.Alumnos;
using InstitutoDesktop.Views.Commons.AnioCarreras;
using InstitutoDesktop.Views.Commons.Aulas;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.Commons.Materias;
using InstitutoDesktop.Views.Horarios;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoDesktop.Services;

namespace InstitutoDesktop
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurar el contenedor de dependencias
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Construir el ServiceProvider
            ServiceProvider = services.BuildServiceProvider();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(DespliegueControladoDeErroresOtroshilos);

            //Application.ThreadException += new ThreadExceptionEventHandler(DespliegueControladoDeErroresHiloPrincipal);
            //configuro el paquete  Microsoft.Extensions.Caching.Memory;


            // Iniciar la aplicación con la inyección de dependencias
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(ServiceProvider.GetRequiredService<MenuPrincipalView>());
        }

        private static void DespliegueControladoDeErroresOtroshilos(object sender, UnhandledExceptionEventArgs args)
        {
            Exception exepcion = (Exception)args.ExceptionObject;

            // MessageBox.Show($"Ha ocurrido un error:{e.Message}{System.Environment.NewLine}Origen del error:{e.Source}");
            var errorView = new ErrorView(exepcion);
            errorView.ShowDialog();
        }

        private static void DespliegueControladoDeErroresHiloPrincipal(object sender, ThreadExceptionEventArgs e)
        {

            //MessageBox.Show($"Ha ocurrido un error:{e.Exception.Message}{System.Environment.NewLine}Origen del error:{e.Exception.Source}");
            var errorView = new ErrorView(e.Exception);
            errorView.ShowDialog();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache(); // Agregar el servicio de caché en memoria
            services.AddScoped<MemoryCacheServiceWinForms>();
            services.AddScoped<MenuPrincipalView>(); // Registrar formularios
            services.AddScoped<CarrerasView>();
            services.AddScoped<AgregarEditarCarreraView>();
            services.AddScoped<AlumnosView>();
            services.AddScoped<AgregarEditarAlumnosView>();
            services.AddScoped<AnioCarrerasView>();
            services.AddScoped<NuevoEditarAnioCarreraView>();
            services.AddScoped<MateriaView>();
            services.AddScoped<NuevoEditarMateriaView>();
            services.AddScoped<AulasView>();
            services.AddScoped<AgregarEditarAulaView>();
            services.AddScoped<DocentesView>();
            services.AddScoped<HorariosView>();
            services.AddScoped<DocentesView>();
            //horas
            services.AddScoped<HorasView>();
            services.AddScoped<AgregarEditarHoraView>();
            //turnos examenes
            services.AddScoped<TurnoExamenesView>();
            services.AddScoped<AgregarEditarTurnoExamenesView>();







        }
    }
}