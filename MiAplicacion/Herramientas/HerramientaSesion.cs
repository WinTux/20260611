using Newtonsoft.Json;

namespace MiAplicacion.Herramientas
{
    public static class HerramientaSesion
    {
        public static void ConvertirObjetoAjson(this ISession sesion, string llave, object valor) {
            sesion.SetString(llave, JsonConvert.SerializeObject(valor));
        }
        public static T ConvertirJsonAobjeto<T>(this ISession sesion, string llave) { 
            var valor = sesion.GetString(llave);
            return valor == null ? default(T) : JsonConvert.DeserializeObject<T>(valor);
        }
    }
}
