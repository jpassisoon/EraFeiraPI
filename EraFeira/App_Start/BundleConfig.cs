using System.Web;
using System.Web.Optimization;

namespace EraFeira
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/bootstrap.bundle.min.js"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js", "~/Scripts/toastr.min.js", "~/Scripts/tinymce/tinymce.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css", "~/Content/toastr.min.css",
                      "~/Content/site.css", "~/Content/DashboardAdministrador.css" /*"~/Content/Home.css","~/Content/Cadastro.css","~/Content/Login.css",
                      "~/Content/EsqueceuSenha.css", "~/Content/Endereco.css",
                      "~/Content/ResumoCompletoPedido.css",
                      "~/Content/AutenticacaoAdministrador.css",
                      "~/Content/Cidade.css", "~/Content/Entregas.css", "~/Content/AreaUsuario.css"*/
                      ));
        }
    }
}
