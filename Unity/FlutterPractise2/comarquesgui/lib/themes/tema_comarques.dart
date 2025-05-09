import 'package:flutter/material.dart';

ThemeData temaComarques = ThemeData(
  textTheme: const TextTheme(
      displayLarge: TextStyle(
        fontFamily: "LeckerliOne",
        fontSize: 36,
        fontWeight: FontWeight.w100,
      ),
      displayMedium: TextStyle(
          fontWeight: FontWeight.w300,
          color: Colors.white,
          fontFamily: "LeckerliOne",
          fontSize: 40,
          shadows: [
            Shadow(offset: Offset(2, 2), color: Colors.black, blurRadius: 3),
          ]),
      displaySmall: TextStyle(
          fontWeight: FontWeight.w300,
          color: Colors.white,
          fontFamily: "LeckerliOne",
          fontSize: 25,
          shadows: [
            Shadow(offset: Offset(2, 2), color: Colors.black, blurRadius: 3),
          ]),
      labelSmall: TextStyle(
          fontWeight: FontWeight.w300,
          color: Colors.black,
          fontFamily: "LeckerliOne",
          fontSize: 25,
          shadows: [
            Shadow(offset: Offset(2, 2), color: Colors.white, blurRadius: 3),
          ]),
      headlineLarge: TextStyle(
          fontWeight: FontWeight.w400,
          color: Colors.black,
          fontFamily: "Merriweather",  
          fontSize: 35,
          ),

      headlineMedium: TextStyle(
          fontWeight: FontWeight.w400,
          color: Colors.black87,
          fontFamily: "Merriweather",  // A good serif alternative could be "Merriweather"
          fontSize: 30,
      ),

      headlineSmall:  TextStyle(
          fontWeight: FontWeight.w400,
          color: Colors.black87,
          fontFamily: "Merriweather",  
          fontSize: 15,
          height: 1.5,  
      ),

      titleMedium: TextStyle(
          fontWeight: FontWeight.bold,
          color: Colors.black87,
          fontFamily: "Merriweather",  // A good serif alternative could be "Merriweather"
          fontSize: 30,
      ),

      titleSmall:  TextStyle(
          fontWeight: FontWeight.bold,
          color: Colors.black87,
          fontFamily: "Merriweather",  
          fontSize: 25,
          height: 1.5,  
      ),
  ),
);
