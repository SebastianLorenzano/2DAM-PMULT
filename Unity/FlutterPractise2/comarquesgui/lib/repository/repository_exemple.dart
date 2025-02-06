import 'package:comarquesgui/models/comarca.dart';
import 'package:comarquesgui/models/provincia.dart';
import 'package:comarquesgui/repository/repository_data.dart';

/* 
    Aquest aclasse accedeix a la classe RepositoryData per tal
    d'obtindre la informació sobre provincies i comarques.
*/
class RepositoryExemple {
  static List<Provincia> obtenirProvincies() {
    // Retorna una llista de provincies, obtingudes a partir de la propietat
    // provincies de RepositoryData.

    List<Provincia> provincies = [];
    for (var p in RepositoryData.provincies) {
      provincies.add(Provincia(nom: p["provincia"], imatge: p["img"]));
    }
    return provincies;
  }

  static List<dynamic> obtenirComarques(String provincia) {
    // Retorna la llista de comarques d'una determinada província.
    
    // Compte, que NO es tracta d'objectes de tipus Comarca,
    // ja que només tenim el nom i la imatge.
    // Es tracta d'un JSON, i per tant és una List<dynamic>
    List<dynamic> comarques = [];

    // Recorrem la llista de provincies en RepositorData per trobar la que es busca
    for (var p in RepositoryData.provincies) {
      if (p["provincia"] == provincia) {
        // Quan trobem la provincia, recorrem les comarques
        // i afegim a la llista comarques un JSON amb el nom
        // i la imatge de cada comarca

        for (var com in p["comarques"]) {
          comarques.add({"nom": com["comarca"], "img": com["img"]});
        }
      }
    }

    return comarques;
  }

  static Comarca? obtenirInfoComarca(String comarca) {

    for (var p in RepositoryData.provincies) {
      for (var com in p["comarques"]) {
        if (com["comarca"] == comarca) {
          return Comarca.fromJSON(com);
        }
      }
    }
    return null;
  }
  
}
