
import 'package:comarquesgui/models/comarca.dart';
import 'package:comarquesgui/repository/repository_exemple.dart';
import 'package:flutter/material.dart';

class InfoComarcaGeneral extends StatelessWidget {
  const InfoComarcaGeneral({super.key});

  @override
  Widget build(BuildContext context) {

    // Agafem la comarca del repositori
    Comarca comarca = RepositoryExemple.obtenirInfoComarca();
    
    // TO-DO
    // Afegir la informació següent sobre la comarca:
    // Imatge, nom, capital i descripció, de forma semblanta com es mostra a l'enunciat

    // Podeu fer ús dels ginys i contenidors que considereu oportuns (Containers, SingleChildScrollView, Columns, etc)
    // Heu de tindre en compte de no sobrepassar els límits i dibuixar fora de l'espai disponible
    // Per comprovar que no se n'eixiu, podeu provar a girar el dispositiu (si esteu fent-ho sobre Android)

    return const Placeholder();
  }
}
