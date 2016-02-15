using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MatrizDato{
	private Dato[,] arreglo;
	private int i, j;

	//Implementar constructor con centro, y posicion inicial
	public MatrizDato(){
		arreglo = new Dato[10, 10];
		i = 0;
		j = 0;
	}

	public void modArr(int I, int J, Vector3 V){
		arreglo[I, J] = new Dato(V.x, V.y, V.z);
	}

	public void modArr(int I, int J){
		arreglo[I, J] = new Dato();
	}

	public void mostrar(){
		Debug.Log("x:" + this.arreglo[i, j].obtV().x + " y:" + this.arreglo[i, j].obtV().y);
	}

	public Vector3 obtV(){
		return(this.arreglo[i, j].obtV());
	}

	public bool movArriba(){
		if(j != 0 && arreglo [i, j - 1].obtB()==true){
			j--;
			return(true);
		}
		return(false);
	}

	public bool movAbajo(){
		if(j != 9 && arreglo [i, j + 1].obtB()==true){
			j++;
			return(true);
		}
		return(false);
	}

	public bool movDerecha(){
		if(i != 9 && arreglo [i + 1, j].obtB()==true){
			i++;
			return(true);
		}
		return(false);
	}

	public bool movIzquierda(){
		if(i != 0 && arreglo [i - 1, j].obtB()==true){
			i--;
			return(true);
		}
		return(false);
	}
}
