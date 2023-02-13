/**
 @Name：layer v3.1.1 Web弹层组件
 @Author：贤心
 @Site：http://layer.layui.com
 @License：MIT
    
 */
!function(n,t){"use strict";var c=n.layui&&layui.define,u,e,f={getPath:function(){var n=document.currentScript?document.currentScript.src:function(){for(var n=document.scripts,i=n.length-1,r,t=i;t>0;t--)if(n[t].readyState==="interactive"){r=n[t].src;break}return r||n[i].src}();return n.substring(0,n.lastIndexOf("/")+1)}(),config:{},end:{},minIndex:0,minLeft:[],btn:["&#x786E;&#x5B9A;","&#x53D6;&#x6D88;"],type:["dialog","page","iframe","loading","tips"],getStyle:function(t,i){var r=t.currentStyle?t.currentStyle:n.getComputedStyle(t,null);return r[r.getPropertyValue?"getPropertyValue":"getAttribute"](i)},link:function(t,r,u){var s,e;if(i.path){s=document.getElementsByTagName("head")[0];e=document.createElement("link");typeof r=="string"&&(u=r);var h=(u||t).replace(/\.|\//g,""),o="layuicss-"+h,c=0;(e.rel="stylesheet",e.href=i.path+t,e.id=o,document.getElementById(o)||s.appendChild(e),typeof r=="function")&&function l(){if(++c>80)return n.console&&console.error("layer.css: Invalid");parseInt(f.getStyle(document.getElementById(o),"width"))===1989?r():setTimeout(l,100)}()}}},i={v:"3.1.1",ie:function(){var t=navigator.userAgent.toLowerCase();return!!n.ActiveXObject||"ActiveXObject"in n?(t.match(/msie\s(\d+)/)||[])[1]||"11":!1}(),index:n.layer&&n.layer.v?1e5:0,path:f.getPath,config:function(n){return(n=n||{},i.cache=f.config=u.extend({},f.config,n),i.path=f.config.path||i.path,typeof n.extend=="string"&&(n.extend=[n.extend]),f.config.path&&i.ready(),!n.extend)?this:(c?layui.addcss("modules/layer/"+n.extend):f.link("theme/"+n.extend),this)},ready:function(n){var t="layer",r=(c?"modules/layer/":"theme/")+"default/layer.css?v="+i.v+"";return c?layui.addcss(r,n,t):f.link(r,n,t),this},alert:function(n,t,r){var f=typeof t=="function";return f&&(r=t),i.open(u.extend({content:n,yes:r},f?{}:t))},confirm:function(n,t,r,e){var o=typeof t=="function";return o&&(e=r,r=t),i.open(u.extend({content:n,btn:f.btn,yes:r,btn2:e},o?{}:t))},msg:function(n,e,o){var c=typeof e=="function",s=f.config.skin,h=(s?s+" "+s+"-msg":"")||"layui-layer-msg",l=r.anim.length-1;return c&&(o=e),i.open(u.extend({content:n,time:3e3,shade:!1,skin:h,title:!1,closeBtn:!1,btn:!1,resize:!1,end:o},c&&!f.config.skin?{skin:h+" layui-layer-hui",anim:l}:function(){return e=e||{},e.icon!==-1&&(e.icon!==t||f.config.skin)||(e.skin=h+" "+(e.skin||"layui-layer-hui")),e}()))},load:function(n,t){return i.open(u.extend({type:3,icon:n||0,resize:!1,shade:.01},t))},tips:function(n,t,r){return i.open(u.extend({type:4,content:[n,t],closeBtn:!1,time:3e3,shade:!1,resize:!1,fixed:!1,maxWidth:210},r))}},o=function(n){var t=this;t.index=++i.index;t.config=u.extend({},t.config,f.config,n);document.body?t.creat():setTimeout(function(){t.creat()},30)},r,s,h;o.pt=o.prototype;r=["layui-layer",".layui-layer-title",".layui-layer-main",".layui-layer-dialog","layui-layer-iframe","layui-layer-content","layui-layer-btn","layui-layer-close"];r.anim=["layer-anim-00","layer-anim-01","layer-anim-02","layer-anim-03","layer-anim-04","layer-anim-05","layer-anim-06"];o.pt.config={type:0,shade:.3,fixed:!0,move:r[1],title:"&#x4FE1;&#x606F;",offset:"auto",area:"auto",closeBtn:1,time:0,zIndex:19891014,maxWidth:360,anim:0,isOutAnim:!0,icon:-1,moveType:1,resize:!0,scrollbar:!0,tips:2};o.pt.vessel=function(n,t){var o=this,e=o.index,i=o.config,s=i.zIndex+e,h=typeof i.title=="object",l=i.maxmin&&(i.type===1||i.type===2),c=i.title?'<div class="layui-layer-title" style="'+(h?i.title[1]:"")+'">'+(h?i.title[0]:i.title)+"<\/div>":"";return i.zIndex=s,t([i.shade?'<div class="layui-layer-shade" id="layui-layer-shade'+e+'" times="'+e+'" style="'+("z-index:"+(s-1)+"; ")+'"><\/div>':"",'<div class="'+r[0]+(" layui-layer-"+f.type[i.type])+((i.type==0||i.type==2)&&!i.shade?" layui-layer-border":"")+" "+(i.skin||"")+'" id="'+r[0]+e+'" type="'+f.type[i.type]+'" times="'+e+'" showtime="'+i.time+'" conType="'+(n?"object":"string")+'" style="z-index: '+s+"; width:"+i.area[0]+";height:"+i.area[1]+(i.fixed?"":";position:absolute;")+'">'+(n&&i.type!=2?"":c)+'<div id="'+(i.id||"")+'" class="layui-layer-content'+(i.type==0&&i.icon!==-1?" layui-layer-padding":"")+(i.type==3?" layui-layer-loading"+i.icon:"")+'">'+(i.type==0&&i.icon!==-1?'<i class="layui-layer-ico layui-layer-ico'+i.icon+'"><\/i>':"")+(i.type==1&&n?"":i.content||"")+'<\/div><span class="layui-layer-setwin">'+function(){var n=l?'<a class="layui-layer-min" href="javascript:;"><cite><\/cite><\/a><a class="layui-layer-ico layui-layer-max" href="javascript:;"><\/a>':"";return i.closeBtn&&(n+='<a class="layui-layer-ico '+r[7]+" "+r[7]+(i.title?i.closeBtn:i.type==4?"1":"2")+'" href="javascript:;"><\/a>'),n}()+"<\/span>"+(i.btn?function(){var t="",n,u;for(typeof i.btn=="string"&&(i.btn=[i.btn]),n=0,u=i.btn.length;n<u;n++)t+='<a class="'+r[6]+""+n+'">'+i.btn[n]+"<\/a>";return'<div class="'+r[6]+" layui-layer-btn-"+(i.btnAlign||"")+'">'+t+"<\/div>"}():"")+(i.resize?'<span class="layui-layer-resize"><\/span>':"")+"<\/div>"],c,u('<div class="layui-layer-move"><\/div>')),o};o.pt.creat=function(){var t=this,n=t.config,o=t.index,s=n.content,h=typeof s=="object",c=u("body"),l;if(!n.id||!u("#"+n.id)[0]){typeof n.area=="string"&&(n.area=n.area==="auto"?["",""]:[n.area,""]);n.shift&&(n.anim=n.shift);i.ie==6&&(n.fixed=!1);switch(n.type){case 0:n.btn="btn"in n?n.btn:f.btn[0];i.closeAll("dialog");break;case 2:s=n.content=h?n.content:[n.content||"http://layer.layui.com","auto"];n.content='<iframe scrolling="'+(n.content[1]||"auto")+'" allowtransparency="true" id="'+r[4]+""+o+'" name="'+r[4]+""+o+'" onload="this.className=\'\';" class="layui-layer-load" frameborder="0" src="'+n.content[0]+'"><\/iframe>';break;case 3:delete n.title;delete n.closeBtn;n.icon===-1&&n.icon===0;i.closeAll("loading");break;case 4:h||(n.content=[n.content,"body"]);n.follow=n.content[1];n.content=n.content[0]+'<i class="layui-layer-TipsG"><\/i>';delete n.title;n.tips=typeof n.tips=="object"?n.tips:[n.tips,!0];n.tipsMore||i.closeAll("tips")}if(t.vessel(h,function(i,e,l){c.append(i[0]);h?function(){n.type==2||n.type==4?function(){u("body").append(i[1])}():function(){s.parents("."+r[0])[0]||(s.data("display",s.css("display")).show().addClass("layui-layer-wrap").wrap(i[1]),u("#"+r[0]+o).find("."+r[5]).before(e))}()}():c.append(i[1]);u(".layui-layer-move")[0]||c.append(f.moveElem=l);t.layero=u("#"+r[0]+o);n.scrollbar||r.html.css("overflow","hidden").attr("layer-full",o)}).auto(o),u("#layui-layer-shade"+t.index).css({"background-color":n.shade[1]||"#000",opacity:n.shade[0]||n.shade}),n.type==2&&i.ie==6&&t.layero.find("iframe").attr("src",s[0]),n.type==4?t.tips():t.offset(),n.fixed)e.on("resize",function(){t.offset();(/^\d+%$/.test(n.area[0])||/^\d+%$/.test(n.area[1]))&&t.auto(o);n.type==4&&t.tips()});if(n.time<=0||setTimeout(function(){i.close(t.index)},n.time),t.move().callback(),r.anim[n.anim]){l="layer-anim "+r.anim[n.anim];t.layero.addClass(l).one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",function(){u(this).removeClass(l)})}n.isOutAnim&&t.layero.data("isOutAnim",!0)}};o.pt.auto=function(n){var h=this,t=h.config,f=u("#"+r[0]+n);t.area[0]===""&&t.maxWidth>0&&(i.ie&&i.ie<8&&t.btn&&f.width(f.innerWidth()),f.outerWidth()>t.maxWidth&&f.width(t.maxWidth));var o=[f.innerWidth(),f.innerHeight()],c=f.find(r[1]).outerHeight()||0,l=f.find("."+r[6]).outerHeight()||0,s=function(n){n=f.find(n);n.height(o[1]-c-l-2*(parseFloat(n.css("padding-top"))|0))};switch(t.type){case 2:s("iframe");break;default:t.area[1]===""?t.maxHeight>0&&f.outerHeight()>t.maxHeight?(o[1]=t.maxHeight,s("."+r[5])):t.fixed&&o[1]>=e.height()&&(o[1]=e.height(),s("."+r[5])):s("."+r[5])}return h};o.pt.offset=function(){var n=this,t=n.config,u=n.layero,i=[u.outerWidth(),u.outerHeight()],f=typeof t.offset=="object";n.offsetTop=(e.height()-i[1])/2;n.offsetLeft=(e.width()-i[0])/2;f?(n.offsetTop=t.offset[0],n.offsetLeft=t.offset[1]||n.offsetLeft):t.offset!=="auto"&&(t.offset==="t"?n.offsetTop=0:t.offset==="r"?n.offsetLeft=e.width()-i[0]:t.offset==="b"?n.offsetTop=e.height()-i[1]:t.offset==="l"?n.offsetLeft=0:t.offset==="lt"?(n.offsetTop=0,n.offsetLeft=0):t.offset==="lb"?(n.offsetTop=e.height()-i[1],n.offsetLeft=0):t.offset==="rt"?(n.offsetTop=0,n.offsetLeft=e.width()-i[0]):t.offset==="rb"?(n.offsetTop=e.height()-i[1],n.offsetLeft=e.width()-i[0]):n.offsetTop=t.offset);t.fixed||(n.offsetTop=/%$/.test(n.offsetTop)?e.height()*parseFloat(n.offsetTop)/100:parseFloat(n.offsetTop),n.offsetLeft=/%$/.test(n.offsetLeft)?e.width()*parseFloat(n.offsetLeft)/100:parseFloat(n.offsetLeft),n.offsetTop+=e.scrollTop(),n.offsetLeft+=e.scrollLeft());u.attr("minLeft")&&(n.offsetTop=e.height()-(u.find(r[1]).outerHeight()||0),n.offsetLeft=u.css("left"));u.css({top:n.offsetTop,left:n.offsetLeft})};o.pt.tips=function(){var c=this,t=c.config,s=c.layero,i=[s.outerWidth(),s.outerHeight()],f=u(t.follow);f[0]||(f=u("body"));var n={width:f.outerWidth(),height:f.outerHeight(),top:f.offset().top,left:f.offset().left},o=s.find(".layui-layer-TipsG"),h=t.tips[0];t.tips[1]||o.remove();n.autoLeft=function(){n.left+i[0]-e.width()>0?(n.tipLeft=n.left+n.width-i[0],o.css({right:12,left:"auto"})):n.tipLeft=n.left};n.where=[function(){n.autoLeft();n.tipTop=n.top-i[1]-10;o.removeClass("layui-layer-TipsB").addClass("layui-layer-TipsT").css("border-right-color",t.tips[1])},function(){n.tipLeft=n.left+n.width+10;n.tipTop=n.top;o.removeClass("layui-layer-TipsL").addClass("layui-layer-TipsR").css("border-bottom-color",t.tips[1])},function(){n.autoLeft();n.tipTop=n.top+n.height+10;o.removeClass("layui-layer-TipsT").addClass("layui-layer-TipsB").css("border-right-color",t.tips[1])},function(){n.tipLeft=n.left-i[0]-10;n.tipTop=n.top;o.removeClass("layui-layer-TipsR").addClass("layui-layer-TipsL").css("border-bottom-color",t.tips[1])}];n.where[h-1]();h===1?n.top-(e.scrollTop()+i[1]+16)<0&&n.where[2]():h===2?e.width()-(n.left+n.width+i[0]+16)>0||n.where[3]():h===3?n.top-e.scrollTop()+n.height+i[1]+16-e.height()>0&&n.where[0]():h===4&&i[0]+16-n.left>0&&n.where[1]();s.find("."+r[5]).css({"background-color":t.tips[1],"padding-right":t.closeBtn?"30px":""});s.css({left:n.tipLeft-(t.fixed?e.scrollLeft():0),top:n.tipTop-(t.fixed?e.scrollTop():0)})};o.pt.move=function(){var o=this,r=o.config,h=u(document),t=o.layero,s=t.find(r.move),c=t.find(".layui-layer-resize"),n={};r.move&&s.css("cursor","move");s.on("mousedown",function(i){i.preventDefault();r.move&&(n.moveStart=!0,n.offset=[i.clientX-parseFloat(t.css("left")),i.clientY-parseFloat(t.css("top"))],f.moveElem.css("cursor","move").show())});c.on("mousedown",function(i){i.preventDefault();n.resizeStart=!0;n.offset=[i.clientX,i.clientY];n.area=[t.outerWidth(),t.outerHeight()];f.moveElem.css("cursor","se-resize").show()});h.on("mousemove",function(u){var h,c,f,s;if(n.moveStart){var f=u.clientX-n.offset[0],s=u.clientY-n.offset[1],l=t.css("position")==="fixed";u.preventDefault();n.stX=l?0:e.scrollLeft();n.stY=l?0:e.scrollTop();r.moveOut||(h=e.width()-t.outerWidth()+n.stX,c=e.height()-t.outerHeight()+n.stY,f<n.stX&&(f=n.stX),f>h&&(f=h),s<n.stY&&(s=n.stY),s>c&&(s=c));t.css({left:f,top:s})}r.resize&&n.resizeStart&&(f=u.clientX-n.offset[0],s=u.clientY-n.offset[1],u.preventDefault(),i.style(o.index,{width:n.area[0]+f,height:n.area[1]+s}),n.isResize=!0,r.resizing&&r.resizing(t))}).on("mouseup",function(){n.moveStart&&(delete n.moveStart,f.moveElem.hide(),r.moveEnd&&r.moveEnd(t));n.resizeStart&&(delete n.resizeStart,f.moveElem.hide())});return o};o.pt.callback=function(){function o(){var r=n.cancel&&n.cancel(t.index,e);r===!1||i.close(t.index)}var t=this,e=t.layero,n=t.config;if(t.openLayer(),n.success)if(n.type==2)e.find("iframe").on("load",function(){n.success(e,t.index)});else n.success(e,t.index);i.ie==6&&t.IE6(e);e.find("."+r[6]).children("a").on("click",function(){var r=u(this).index(),f;r===0?n.yes?n.yes(t.index,e):n.btn1?n.btn1(t.index,e):i.close(t.index):(f=n["btn"+(r+1)]&&n["btn"+(r+1)](t.index,e),f===!1||i.close(t.index))});e.find("."+r[7]).on("click",o);if(n.shadeClose)u("#layui-layer-shade"+t.index).on("click",function(){i.close(t.index)});e.find(".layui-layer-min").on("click",function(){var r=n.min&&n.min(e);r===!1||i.min(t.index,n)});e.find(".layui-layer-max").on("click",function(){u(this).hasClass("layui-layer-maxmin")?(i.restore(t.index),n.restore&&n.restore(e)):(i.full(t.index,n),setTimeout(function(){n.full&&n.full(e)},100))});n.end&&(f.end[t.index]=n.end)};f.reselect=function(){u.each(u("select"),function(){var n=u(this);n.parents("."+r[0])[0]||n.attr("layer")==1&&u("."+r[0]).length<1&&n.removeAttr("layer").show();n=null})};o.pt.IE6=function(){u("select").each(function(){var n=u(this);n.parents("."+r[0])[0]||n.css("display")==="none"||n.attr({layer:"1"}).hide();n=null})};o.pt.openLayer=function(){var n=this;i.zIndex=n.config.zIndex;i.setTop=function(n){var t=function(){i.zIndex++;n.css("z-index",i.zIndex+1)};i.zIndex=parseInt(n[0].style.zIndex);n.on("mousedown",t);return i.zIndex}};f.record=function(n){var t=[n.width(),n.height(),n.position().top,n.position().left+parseFloat(n.css("margin-left"))];n.find(".layui-layer-max").addClass("layui-layer-maxmin");n.attr({area:t})};f.rescollbar=function(n){r.html.attr("layer-full")==n&&(r.html[0].style.removeProperty?r.html[0].style.removeProperty("overflow"):r.html[0].style.removeAttribute("overflow"),r.html.removeAttr("layer-full"))};n.layer=i;i.getChildFrame=function(n,t){return t=t||u("."+r[4]).attr("times"),u("#"+r[0]+t).find("iframe").contents().find(n)};i.getFrameIndex=function(n){return u("#"+n).parents("."+r[4]).attr("times")};i.iframeAuto=function(n){if(n){var f=i.getChildFrame("html",n).outerHeight(),t=u("#"+r[0]+n),e=t.find(r[1]).outerHeight()||0,o=t.find("."+r[6]).outerHeight()||0;t.css({height:f+e+o});t.find("iframe").css({height:f})}};i.iframeSrc=function(n,t){u("#"+r[0]+n).find("iframe").attr("src",t)};i.style=function(n,t,i){var e=u("#"+r[0]+n),h=e.find(".layui-layer-content"),c=e.attr("type"),s=e.find(r[1]).outerHeight()||0,o=e.find("."+r[6]).outerHeight()||0,l=e.attr("minLeft");c!==f.type[3]&&c!==f.type[4]&&(i||(parseFloat(t.width)<=260&&(t.width=260),parseFloat(t.height)-s-o<=64&&(t.height=64+s+o)),e.css(t),o=e.find("."+r[6]).outerHeight(),c===f.type[2]?e.find("iframe").css({height:parseFloat(t.height)-s-o}):h.css({height:parseFloat(t.height)-s-o-parseFloat(h.css("padding-top"))-parseFloat(h.css("padding-bottom"))}))};i.min=function(n){var t=u("#"+r[0]+n),s=t.find(r[1]).outerHeight()||0,o=t.attr("minLeft")||181*f.minIndex+"px",h=t.css("position");f.record(t);f.minLeft[0]&&(o=f.minLeft[0],f.minLeft.shift());t.attr("position",h);i.style(n,{width:180,height:s,left:o,top:e.height()-s,position:"fixed",overflow:"hidden"},!0);t.find(".layui-layer-min").hide();t.attr("type")==="page"&&t.find(r[4]).hide();f.rescollbar(n);t.attr("minLeft")||f.minIndex++;t.attr("minLeft",o)};i.restore=function(n){var t=u("#"+r[0]+n),e=t.attr("area").split(","),o=t.attr("type");i.style(n,{width:parseFloat(e[0]),height:parseFloat(e[1]),top:parseFloat(e[2]),left:parseFloat(e[3]),position:t.attr("position"),overflow:"visible"},!0);t.find(".layui-layer-max").removeClass("layui-layer-maxmin");t.find(".layui-layer-min").show();t.attr("type")==="page"&&t.find(r[4]).show();f.rescollbar(n)};i.full=function(n){var t=u("#"+r[0]+n),o;f.record(t);r.html.attr("layer-full")||r.html.css("overflow","hidden").attr("layer-full",n);clearTimeout(o);o=setTimeout(function(){var r=t.css("position")==="fixed";i.style(n,{top:r?0:e.scrollTop(),left:r?0:e.scrollLeft(),width:e.width(),height:e.height()},!0);t.find(".layui-layer-min").hide()},100)};i.title=function(n,t){var f=u("#"+r[0]+(t||i.index)).find(r[1]);f.html(n)};i.close=function(n){var t=u("#"+r[0]+n),s=t.attr("type"),e,o;t[0]&&(e="layui-layer-wrap",o=function(){var i,h,o;if(s===f.type[1]&&t.attr("conType")==="object"){for(t.children(":not(."+r[5]+")").remove(),i=t.find("."+e),h=0;h<2;h++)i.unwrap();i.css("display",i.data("display")).removeClass(e)}else{if(s===f.type[2])try{o=u("#"+r[4]+n)[0];o.contentWindow.document.write("");o.contentWindow.close();t.find("."+r[5])[0].removeChild(o)}catch(c){}t[0].innerHTML="";t.remove()}typeof f.end[n]=="function"&&f.end[n]();delete f.end[n]},t.data("isOutAnim")&&t.addClass("layer-anim layer-anim-close"),u("#layui-layer-moves, #layui-layer-shade"+n).remove(),i.ie==6&&f.reselect(),f.rescollbar(n),t.attr("minLeft")&&(f.minIndex--,f.minLeft.push(t.attr("minLeft"))),i.ie&&i.ie<10||!t.data("isOutAnim")?o():setTimeout(function(){o()},200))};i.closeAll=function(n){u.each(u("."+r[0]),function(){var t=u(this),r=n?t.attr("type")===n:1;r&&i.close(t.attr("times"));r=null})};s=i.cache||{};h=function(n){return s.skin?" "+s.skin+" "+s.skin+"-"+n:""};i.prompt=function(n,t){var s="",f,r,c,o;return n=n||{},typeof n=="function"&&(t=n),n.area&&(f=n.area,s='style="width: '+f[0]+"; height: "+f[1]+';"',delete n.area),c=n.formType==2?'<textarea class="layui-layer-input"'+s+">"+(n.value||"")+"<\/textarea>":function(){return'<input type="'+(n.formType==1?"password":"text")+'" class="layui-layer-input" value="'+(n.value||"")+'">'}(),o=n.success,delete n.success,i.open(u.extend({type:1,btn:["&#x786E;&#x5B9A;","&#x53D6;&#x6D88;"],content:c,skin:"layui-layer-prompt"+h("prompt"),maxWidth:e.width(),success:function(n){r=n.find(".layui-layer-input");r.focus();typeof o=="function"&&o(n)},resize:!1,yes:function(u){var f=r.val();f===""?r.focus():f.length>(n.maxlength||500)?i.tips("&#x6700;&#x591A;&#x8F93;&#x5165;"+(n.maxlength||500)+"&#x4E2A;&#x5B57;&#x6570;",r,{tips:1}):t&&t(f,u,r)}},n))};i.tab=function(n){n=n||{};var t=n.tab||{},r="layui-this",f=n.success;return delete n.success,i.open(u.extend({type:1,skin:"layui-layer-tab"+h("tab"),resize:!1,title:function(){var u=t.length,n=1,i="";if(u>0)for(i='<span class="'+r+'">'+t[0].title+"<\/span>";n<u;n++)i+="<span>"+t[n].title+"<\/span>";return i}(),content:'<ul class="layui-layer-tabmain">'+function(){var u=t.length,n=1,i="";if(u>0)for(i='<li class="layui-layer-tabli '+r+'">'+(t[0].content||"no content")+"<\/li>";n<u;n++)i+='<li class="layui-layer-tabli">'+(t[n].content||"no  content")+"<\/li>";return i}()+"<\/ul>",success:function(t){var i=t.find(".layui-layer-title").children(),e=t.find(".layui-layer-tabmain").children();i.on("mousedown",function(t){t.stopPropagation?t.stopPropagation():t.cancelBubble=!0;var i=u(this),f=i.index();i.addClass(r).siblings().removeClass(r);e.eq(f).show().siblings().hide();typeof n.change=="function"&&n.change(f)});typeof f=="function"&&f(t)}},n))};i.photos=function(t,r,f){function p(n,t,i){var r=new Image;if(r.src=n,r.complete)return t(r);r.onload=function(){r.onload=null;t(r)};r.onerror=function(n){r.onerror=null;i(n)}}var e={},l,a,v;if(t=t||{},t.photos){var y=t.photos.constructor===Object,c=y?t.photos:{},o=c.data||[],s=c.start||0;if(e.imgIndex=(s|0)+1,t.img=t.img||"img",l=t.success,delete t.success,y){if(o.length===0)return i.msg("&#x6CA1;&#x6709;&#x56FE;&#x7247;")}else{if(a=u(t.photos),v=function(){o=[];a.find(t.img).each(function(n){var t=u(this);t.attr("layer-index",n);o.push({alt:t.attr("alt"),pid:t.attr("layer-pid"),src:t.attr("layer-src")||t.attr("src"),thumb:t.attr("src")})})},v(),o.length===0)return;if(r||a.on("click",t.img,function(){var n=u(this),r=n.attr("layer-index");i.photos(u.extend(t,{photos:{start:r,data:o,tab:t.tab},full:t.full}),!0);v()}),!r)return}e.imgprev=function(n){e.imgIndex--;e.imgIndex<1&&(e.imgIndex=o.length);e.tabimg(n)};e.imgnext=function(n,t){(e.imgIndex++,e.imgIndex>o.length&&(e.imgIndex=1,t))||e.tabimg(n)};e.keyup=function(n){if(!e.end){var t=n.keyCode;n.preventDefault();t===37?e.imgprev(!0):t===39?e.imgnext(!0):t===27&&i.close(e.index)}};e.tabimg=function(n){if(!(o.length<=1))return c.start=e.imgIndex-1,i.close(e.index),i.photos(t,!0,n)};e.event=function(){e.bigimg.hover(function(){e.imgsee.show()},function(){e.imgsee.hide()});e.bigimg.find(".layui-layer-imgprev").on("click",function(n){n.preventDefault();e.imgprev()});e.bigimg.find(".layui-layer-imgnext").on("click",function(n){n.preventDefault();e.imgnext()});u(document).on("keyup",e.keyup)};e.loadi=i.load(1,{shade:"shade"in t?!1:.9,scrollbar:!1});p(o[s].src,function(r){i.close(e.loadi);e.index=i.open(u.extend({type:1,id:"layui-layer-photos",area:function(){var i=[r.width,r.height],e=[u(n).width()-100,u(n).height()-100],f;return!t.full&&(i[0]>e[0]||i[1]>e[1])&&(f=[i[0]/e[0],i[1]/e[1]],f[0]>f[1]?(i[0]=i[0]/f[0],i[1]=i[1]/f[0]):f[0]<f[1]&&(i[0]=i[0]/f[1],i[1]=i[1]/f[1])),[i[0]+"px",i[1]+"px"]}(),title:!1,shade:.9,shadeClose:!0,closeBtn:!1,move:".layui-layer-phimg img",moveType:1,scrollbar:!1,moveOut:!0,isOutAnim:!1,skin:"layui-layer-photos"+h("photos"),content:'<div class="layui-layer-phimg"><img src="'+o[s].src+'" alt="'+(o[s].alt||"")+'" layer-pid="'+o[s].pid+'"><div class="layui-layer-imgsee">'+(o.length>1?'<span class="layui-layer-imguide"><a href="javascript:;" class="layui-layer-iconext layui-layer-imgprev"><\/a><a href="javascript:;" class="layui-layer-iconext layui-layer-imgnext"><\/a><\/span>':"")+'<div class="layui-layer-imgbar" style="display:'+(f?"block":"")+'"><span class="layui-layer-imgtit"><a href="javascript:;">'+(o[s].alt||"")+"<\/a><em>"+e.imgIndex+"/"+o.length+"<\/em><\/span><\/div><\/div><\/div>",success:function(n){e.bigimg=n.find(".layui-layer-phimg");e.imgsee=n.find(".layui-layer-imguide,.layui-layer-imgbar");e.event(n);t.tab&&t.tab(o[s],n);typeof l=="function"&&l(n)},end:function(){e.end=!0;u(document).off("keyup",e.keyup)}},t))},function(){i.close(e.loadi);i.msg("&#x5F53;&#x524D;&#x56FE;&#x7247;&#x5730;&#x5740;&#x5F02;&#x5E38;<br>&#x662F;&#x5426;&#x7EE7;&#x7EED;&#x67E5;&#x770B;&#x4E0B;&#x4E00;&#x5F20;&#xFF1F;",{time:3e4,btn:["&#x4E0B;&#x4E00;&#x5F20;","&#x4E0D;&#x770B;&#x4E86;"],yes:function(){o.length>1&&e.imgnext(!0,!0)}})})}};f.run=function(t){u=t;e=u(n);r.html=u("html");i.open=function(n){var t=new o(n);return t.index}};n.layui&&layui.define?(i.ready(),layui.define("jquery",function(t){i.path=layui.cache.dir;f.run(layui.$);n.layer=i;t("layer",i)})):typeof define=="function"&&define.amd?define(["jquery"],function(){return f.run(n.jQuery),i}):function(){f.run(n.jQuery);i.ready()}()}(window);