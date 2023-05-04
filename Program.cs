/*
Implemente una clase Region que implemente los atributos Nombre y Superficie.
Implemente otra clase Pais que herede de Region y agregue los atributos OrganizacionPolitica e Idioma.
El primer atributo se implementará con un enumerador público con los valores: “República”, “Monarquía”, “Imperio”, “Otro”.
Implemente otra clase Ciudad que herede de Region y agregue el atributo de tipo Boolean CiudadCapital. 
Implemente una clase Continente que herede de Region.
La clase Continente tendrá una colección de Paises.
La clase Pais tendrá una colección de Ciudades de igual forma.
Elabore la aplicación necesaria para generar instancias de las clases e invocar sus miembros.
Calcule la superficie total de un continente teniendo en cuenta la superficie de sus países que a la vez cuentan con ciudades.
*/

var buenosaires=new Ciudad();
buenosaires.Nombre="Buenos Aires";
buenosaires.CiudadCapital=true;
buenosaires.Superficie=10000;

var cordoba=new Ciudad();
cordoba.Nombre="Cordoba";
cordoba.CiudadCapital=false;
cordoba.Superficie=15000;

var rio=new Ciudad();
rio.Nombre="Rio de Janeiro";
rio.CiudadCapital=false;
rio.Superficie=5000;

var sanpablo=new Ciudad();
sanpablo.Nombre="San Pablo";
sanpablo.CiudadCapital=false;
sanpablo.Superficie=6000;

var Argentina=new Pais();
Argentina.Idioma="Espanol";
Argentina.OrganizacionPolitica=Pais.TipoOrganizacion.Republica;
Argentina.Ciudades.Add(buenosaires);
Argentina.Ciudades.Add(cordoba);

var Brasil=new Pais();
Brasil.Idioma="Portugues";
Brasil.OrganizacionPolitica=Pais.TipoOrganizacion.Republica;
Brasil.Ciudades.Add(rio);
Brasil.Ciudades.Add(sanpablo);

var continente=new Continente();
continente.Paises.Add(Argentina);
continente.Paises.Add(Brasil);

continente.MostrarNombre();
Brasil.MostrarNombre();
Console.WriteLine(continente.Calcular());
//var region1=new Region();


abstract class Region{// Class Region (Abstract) no se puede crear objetos, instancias de Region (SOLO SE PUEDEN INSTANCIAR SUS CLASES DERIVADAS)
    public string Nombre{get;set;}
    public int Superficie{get;set;}

    public abstract int Calcular(); //sin implementacion {} // El comportamiento no va a estar acá. Se implementan en las clases derivadas. Y cada uno tendrá su propia implementación y actuará distinto.
    // Se podría llamar llamar miembros u/o metodos abstractos. --- SIN IMPLEMENTACION, SIN LLAVES
    public void MostrarNombre(){ // metodo de instancia.
        Console.WriteLine(this.Nombre);
    }
}

class Pais :Region {
    new public void MostrarNombre(){ // mi propio mostrar nombre (versionado) // darle una nueva implementacion // Se agrega new al principio.
        Console.WriteLine("mensaje"); // le damos una nueva implementacion a ese metodo de la clase derivada
    }
    public enum TipoOrganizacion{
        Republica,
        Monarquia,
        Imperio,
        Otro
    }
    public TipoOrganizacion OrganizacionPolitica{get;set;}
    public string Idioma{get;set;}
    public List<Ciudad> Ciudades{get;set;}=new List<Ciudad>();

    public override int Calcular() // sobrescritura (Su propia implementación en la clase derivada)
    {
        //le doy implementacion
        var superficiepais=0; // Calcular (sumar la superficie de todas las ciudades)
        foreach(var ciud in Ciudades){
            //this.Superficie+=ciud.Calcular();
            //superficepais+=ciud.Superficie;
            superficiepais+=ciud.Calcular();
        }
        return superficiepais;
    }
}

class Ciudad:Region {
    public bool CiudadCapital{get;set;}

    public override int Calcular()
    {
         return this.Superficie;
    }
}

sealed class Continente:Region{
    public List<Pais> Paises{get;set;}=new List<Pais>();
    public override int Calcular()
    {
            var superficiecontinente=0;
            foreach(var pais in Paises){
                superficiecontinente+=pais.Calcular();
            }
            return superficiecontinente;
    }
}
/*
class Subcontinente:Continente{

}
*/