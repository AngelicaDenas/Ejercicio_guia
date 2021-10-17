#include <stdio.h>
#include <string.h>
#include <stdlib.h> //si utilizamos la funcion atoi

int main (int arg, char *argv []){
	 char peticion[100];
	 strcpy (peticion, "2/Angelica/23/1.65");
	 //para descomponer en pedasos 
	 int codigo;
	 char nombre[20];
	 int edad;
	 float altura;
	 
	 char *p = strtok (peticion,"/");
	codigo = atoi (p);
	p = strtok(NULL,"/");
	strcpy(nombre, p);
	p = strtok(NULL,"/");
	edad = atoi (p);
	p = strtok(NULL,"/");
	altura = atof (p);
	
	printf("Codigo: %d, nombre: %s, edad: %d, altura: %f", codigo, nombre, edad, altura);
	 
	
	
	
}
