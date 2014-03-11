//运动通用框架(如，变宽，渐变等)
//调用方法，在前台对象上添加自定义属性obj.timer作为各自定时器
//示例：startMove(obj,'font-size',50);

//By: Changjiang,2014/03/03

var timer = null;
function startMove(obj, attr, iTarget) {
    clearInterval(obj.timer);
    obj.timer = setInterval(function () {
        var c;
        if (attr == 'opacity') {
            c = Math.round(parseInt(getStyle(obj, attr))*100);
        }
        else {
            c = parseInt(getStyle(obj, attr));
        }
        var speed = (iTarget - c) / 2;
        speed = speed > 0 ? Math.ceil(speed) : Math.floor(speed);
        if (c == iTarget) {
            clearInterval(obj.timer);
        }
        else {
            if (attr == 'opacity') {
                obj.style.filter = 'alpha(opacity=' + (c + speed)+')';
                obj.style.opacity = (c + speed)/100;
            }
            obj.style[attr] = c + speed + 'px';
        }
    }, 30);
}

//获取样式
function getStyle(obj, name) {
    if (obj.currentStyle) {
        return obj.currentStyle[name];
    }
    else {
        return getComputedStyle(obj, false)[name];
    }
}
