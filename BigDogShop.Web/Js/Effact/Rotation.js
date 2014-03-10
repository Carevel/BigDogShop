$(document).ready(function () {

    /*rotate转变*/
	$('.imageRotation').each(function(){
		var imageRotation=this,
			imageBox=$(imageRotation).children('.imageBox')[0],
			titleBox=$(imageRotation).children('.titleBox')[0],
			titleArr=$(titleBox).children(),
			icoBox=$(imageRotation).children('.icoBox')[0],
			icoArr=$(icoBox).children(),
			imageWidth=$(imageRotation).width(),
			imageNum=$(imageBox).children().size(),
			imageRealWidth=imageWidth*imageNum,
			activeID=parseInt($($(icoBox).children('.active')[0]).attr("rel")),
			nextID=0,
			setIntervalID,
			intervalTime=3000,
			imageSpeed=400,
			titleSpeed=250;

		$(imageBox).css({'width':imageRealWidth+'px'});

		//图片轮换函数
		var rotate=function  (clickID) {
			if(clickID){
				nextID=clickID;
			}
			else{
				nextID=activeID<=5?activeID+1:1;	
			}
			//交换图标
			$(icoArr[activeID-1]).removeClass("active");
			$(icoArr[nextID-1]).addClass("active");

			$(titleArr[activeID-1]).animate(
				{bottom:"-40px"},
				titleSpeed,function  () {
					$(titleArr[nextID-1]).animate({bottom:"0px"},titleSpeed);
				}
			);

			//图片交换
			$(imageBox).animate({left:"-"+(nextID-1)*imageWidth+"px"},imageSpeed);
			//ID交换
			activeID=nextID;
		}

		setIntervalID=setInterval(rotate,intervalTime);
		
		$(imageBox).hover(
			function  () {
				clearInterval(setIntervalID);
			},
			function(){
				setIntervalID=setInterval(rotate,intervalTime);
			}
		);

		$(icoArr).click(function(){
			clearInterval(setIntervalID);
			var clickID=parseInt($(this).attr("rel"));
			rotate(clickID);
			setIntervalID=setInterval(rotate,intervalTime);
		});
	});


    /*slide转变*/


});