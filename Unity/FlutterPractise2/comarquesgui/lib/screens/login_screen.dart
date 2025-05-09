import 'package:comarquesgui/screens/provincies_screen.dart';
import 'package:flutter/material.dart';

class LoginScreen extends StatelessWidget {
  LoginScreen({super.key});
  
  static const String LOGIN_USER = "admin";
  static const String LOGIN_PASSWORD = "admin";
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  TextEditingController userController = TextEditingController();
  TextEditingController passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Center(
        child: Padding(
          padding: const EdgeInsets.all(15.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text("Iniciar Sesión", style: Theme.of(context).textTheme.titleSmall,),
              const SizedBox(height: 20),
              TextFormField(
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "No puede estar vacío";
                  }
                  return null;
                },
                autofocus: true,
                keyboardType: TextInputType.emailAddress,
                controller: userController,
                decoration: InputDecoration(
                  hintText: "Correo Electronico",
                  border: OutlineInputBorder(borderRadius: BorderRadius.circular(20)),
                  icon: const Icon(Icons.email_rounded),
                ),
              ),
              const SizedBox(height: 20),
              TextFormField(
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "No puede estar vacío";
                  }
                  return null;
                },
                obscureText: true,
                controller: passwordController,
                decoration: InputDecoration(
                  hintText: "Contraseña",
                  border: OutlineInputBorder(borderRadius: BorderRadius.circular(20)),
                  icon: const Icon(Icons.lock),
                ),
              ),
              const SizedBox(height: 20),
              ElevatedButton(
                style: ButtonStyle(
                  shape: WidgetStateProperty.all<RoundedRectangleBorder>(const RoundedRectangleBorder(borderRadius: BorderRadius.zero)
                  )
                ),
                child: const Text("Iniciar Sesión"),
                onPressed: () {
                  if (_formKey.currentState?.validate() ?? true) {
                    Navigator.push(context, MaterialPageRoute(builder: (context) => const ProvinciesScreen()));
                  }
                  else {
                    showDialog(
                      context: context,
                      builder: (context) {
                        return AlertDialog(
                          title: const Text("Error"),
                          content: const Text("El usuario o la contraseña son incorrectas"),
                          actions: [
                            TextButton(
                              onPressed: () {
                              Navigator.pop(context, "Volver");
                              },
                              child: const Text("Volver"),
                            ),
                            TextButton(
                              onPressed: () {
                                userController.text = LOGIN_USER;  
                                passwordController.text = LOGIN_PASSWORD;
                                Navigator.pop(context, "Rellenar usuario");

                              },
                              child: const Text("Rellenar Usuario"),
                            ),
                          ],
                        );
                      },
                    );
                  }
                },
              ),
            ],
          ),
        ),
      ),
    );
  }

}