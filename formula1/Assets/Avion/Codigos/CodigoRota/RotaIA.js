@script AddComponentMenu("Camera-Control/Smooth Follow")

	var Misil : boolean = false;

	var RotaMisil : float = 10;
	
	private var auxRotaMisil : float = 0;
	
    var target : Transform;

    var distance : float = 10.0;
  
    var height : float = 1.3;
    
    var heightDamping : float = 4.0;  
       
    function LateUpdate () {
    
    wantedHeight = target.position.y + height;
     
    currentRotationAngle = transform.eulerAngles.y;
    currentHeight = transform.position.y;
     
    currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);    
    currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

    transform.position = target.position;
    transform.position -= currentRotation * Vector3.forward * distance;    
 
    transform.position.y = currentHeight;
  	if(!Misil){
    	transform.LookAt (target);
    }else{
    	
    	auxRotaMisil += RotaMisil * Time.deltaTime;
    	transform.localRotation = Quaternion.Euler (0, 90, auxRotaMisil);
    }
    }