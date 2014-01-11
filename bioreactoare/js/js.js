$(window).scroll(function(){
	var top = $(window).scrollTop();
	if ((top> 50) && top<150){
		$("#left-sidebar-text").css("margin-top", "-"+top+"px");
	}
	else{
		if ((top < 50)){
			$("#left-sidebar-text").css("margin-top", "0px");
		}
		if (top > 150){
			$("#left-sidebar-text").css("margin-top", "-150px");
		}
	}
});