@script AddComponentMenu("Camera-Control/Smooth Follow")

    var target : Transform;

    var distance : float = 10.0;
  
    var height : float = 1.3;
    
    var Tiempo : float = 0.0;
    
    var heightDamping : float = 4.0;  
       
    function FixedUpdate () {
    
    if(Tiempo <= 3.0){
    	Tiempo += Time.deltaTime;
    	heightDamping = 1.5;
    
    }else{
    	
    	heightDamping = 4.0;
    }
    
    wantedHeight = target.position.y + height;
     
    currentRotationAngle = transform.eulerAngles.y;
    currentHeight = transform.position.y;
     
    currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);    
    currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
     

    transform.position = target.position;
    transform.position -= currentRotation * Vector3.forward * distance;    
 
    transform.position.y = currentHeight;
  
    transform.LookAt (target);
    }