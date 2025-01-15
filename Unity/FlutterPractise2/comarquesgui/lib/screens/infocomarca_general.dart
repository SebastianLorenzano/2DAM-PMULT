
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
// Add the following information about the comarca:
// Image, name, capital, and description, in a way similar to what is shown in the instructions.

// You can use any widgets and containers you find appropriate (Containers, SingleChildScrollView, Columns, etc).
// You must ensure that you do not exceed the boundaries and draw outside the available space.
// To check that you don't go out of bounds, you can try rotating the device (if you're testing it on Android).
    return const Placeholder();
  }
}
