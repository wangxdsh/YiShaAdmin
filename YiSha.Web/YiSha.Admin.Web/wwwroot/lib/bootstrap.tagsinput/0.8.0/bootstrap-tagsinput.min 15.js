(function(n){"use strict";function i(t,i){this.isInit=!0;this.itemsArray=[];this.$element=n(t);this.$element.hide();this.isSelect=t.tagName==="SELECT";this.multiple=this.isSelect&&t.hasAttribute("multiple");this.objectItems=i&&i.itemValue;this.placeholderText=t.hasAttribute("placeholder")?this.$element.attr("placeholder"):"";this.inputSize=Math.max(1,this.placeholderText.length);this.$container=n('<div class="bootstrap-tagsinput"><\/div>');this.$input=n('<input type="text" placeholder="'+this.placeholderText+'"/>').appendTo(this.$container);this.$element.before(this.$container);this.build(i);this.isInit=!1}function u(n,t){if(typeof n[t]!="function"){var i=n[t];n[t]=function(n){return n[i]}}}function f(n,t){if(typeof n[t]!="function"){var i=n[t];n[t]=function(){return i}}}function t(n){return n?e.text(n).html():""}function o(n){var t=0,i;return document.selection?(n.focus(),i=document.selection.createRange(),i.moveStart("character",-n.value.length),t=i.text.length):(n.selectionStart||n.selectionStart=="0")&&(t=n.selectionStart),t}function s(t,i){var r=!1;return n.each(i,function(n,i){if(typeof i=="number"&&t.which===i)return r=!0,!1;if(t.which===i.which){var u=!i.hasOwnProperty("altKey")||t.altKey===i.altKey,f=!i.hasOwnProperty("shiftKey")||t.shiftKey===i.shiftKey,e=!i.hasOwnProperty("ctrlKey")||t.ctrlKey===i.ctrlKey;if(u&&f&&e)return r=!0,!1}}),r}var r={tagClass:function(){return"label label-info"},focusClass:"focus",itemValue:function(n){return n?n.toString():n},itemText:function(n){return this.itemValue(n)},itemTitle:function(){return null},freeInput:!0,addOnBlur:!0,maxTags:undefined,maxChars:undefined,confirmKeys:[13,44],delimiter:",",delimiterRegex:null,cancelConfirmKeysOnEmpty:!1,onTagExists:function(n,t){t.hide().fadeIn()},trimValue:!1,allowDuplicates:!1,triggerChange:!0},e;i.prototype={constructor:i,add:function(i,r,u){var f=this,a,e,o,w,l,h,b,c;if((!f.options.maxTags||!(f.itemsArray.length>=f.options.maxTags))&&(i===!1||i)){if(typeof i=="string"&&f.options.trimValue&&(i=n.trim(i)),typeof i=="object"&&!f.objectItems)throw"Can't add objects when itemValue option is not set";if(!i.toString().match(/^\s*$/)){if(f.isSelect&&!f.multiple&&f.itemsArray.length>0&&f.remove(f.itemsArray[0]),typeof i=="string"&&this.$element[0].tagName==="INPUT"&&(a=f.options.delimiterRegex?f.options.delimiterRegex:f.options.delimiter,e=i.split(a),e.length>1)){for(o=0;o<e.length;o++)this.add(e[o],!0);r||f.pushVal(f.options.triggerChange);return}var s=f.options.itemValue(i),v=f.options.itemText(i),k=f.options.tagClass(i),y=f.options.itemTitle(i),p=n.grep(f.itemsArray,function(n){return f.options.itemValue(n)===s})[0];if(p&&!f.options.allowDuplicates){if(f.options.onTagExists){w=n(".tag",f.$container).filter(function(){return n(this).data("item")===p});f.options.onTagExists(i,w)}return}f.items().toString().length+i.length+1>f.options.maxInputLength||(l=n.Event("beforeItemAdd",{item:i,cancel:!1,options:u}),f.$element.trigger(l),l.cancel)||(f.itemsArray.push(i),h=n('<span class="tag '+t(k)+(y!==null?'" title="'+y:"")+'">'+t(v)+'<span data-role="remove"><\/span><\/span>'),h.data("item",i),f.findInputWrapper().before(h),h.after(" "),b=n('option[value="'+encodeURIComponent(s)+'"]',f.$element).length||n('option[value="'+t(s)+'"]',f.$element).length,f.isSelect&&!b&&(c=n("<option selected>"+t(v)+"<\/option>"),c.data("item",i),c.attr("value",s),f.$element.append(c)),r||f.pushVal(f.options.triggerChange),(f.options.maxTags===f.itemsArray.length||f.items().toString().length===f.options.maxInputLength)&&f.$container.addClass("bootstrap-tagsinput-max"),n(".typeahead, .twitter-typeahead",f.$container).length&&f.$input.typeahead("val",""),this.isInit?f.$element.trigger(n.Event("itemAddedOnInit",{item:i,options:u})):f.$element.trigger(n.Event("itemAdded",{item:i,options:u})))}}},remove:function(t,i,r){var u=this,f;if(u.objectItems&&(t=typeof t=="object"?n.grep(u.itemsArray,function(n){return u.options.itemValue(n)==u.options.itemValue(t)}):n.grep(u.itemsArray,function(n){return u.options.itemValue(n)==t}),t=t[t.length-1]),t){if(f=n.Event("beforeItemRemove",{item:t,cancel:!1,options:r}),u.$element.trigger(f),f.cancel)return;n(".tag",u.$container).filter(function(){return n(this).data("item")===t}).remove();n("option",u.$element).filter(function(){return n(this).data("item")===t}).remove();n.inArray(t,u.itemsArray)!==-1&&u.itemsArray.splice(n.inArray(t,u.itemsArray),1)}i||u.pushVal(u.options.triggerChange);u.options.maxTags>u.itemsArray.length&&u.$container.removeClass("bootstrap-tagsinput-max");u.$element.trigger(n.Event("itemRemoved",{item:t,options:r}))},removeAll:function(){var t=this;for(n(".tag",t.$container).remove(),n("option",t.$element).remove();t.itemsArray.length>0;)t.itemsArray.pop();t.pushVal(t.options.triggerChange)},refresh:function(){var i=this;n(".tag",i.$container).each(function(){var r=n(this),u=r.data("item"),e=i.options.itemValue(u),o=i.options.itemText(u),s=i.options.tagClass(u),f;r.attr("class",null);r.addClass("tag "+t(s));r.contents().filter(function(){return this.nodeType==3})[0].nodeValue=t(o);i.isSelect&&(f=n("option",i.$element).filter(function(){return n(this).data("item")===u}),f.attr("value",e))})},items:function(){return this.itemsArray},pushVal:function(){var t=this,i=n.map(t.items(),function(n){return t.options.itemValue(n).toString()});t.$element.val(i,!0);t.options.triggerChange&&t.$element.trigger("change")},build:function(t){var i=this,h;if(i.options=n.extend({},r,t),i.objectItems&&(i.options.freeInput=!1),u(i.options,"itemValue"),u(i.options,"itemText"),f(i.options,"tagClass"),i.options.typeahead&&(h=i.options.typeahead||{},f(h,"source"),i.$input.typeahead(n.extend({},h,{source:function(t,r){function f(n){for(var u,f=[],t=0;t<n.length;t++)u=i.options.itemText(n[t]),e[u]=n[t],f.push(u);r(f)}this.map={};var e=this.map,u=h.source(t);n.isFunction(u.success)?u.success(f):n.isFunction(u.then)?u.then(f):n.when(u).then(f)},updater:function(n){return i.add(this.map[n]),this.map[n]},matcher:function(n){return n.toLowerCase().indexOf(this.query.trim().toLowerCase())!==-1},sorter:function(n){return n.sort()},highlighter:function(n){var t=new RegExp("("+this.query+")","gi");return n.replace(t,"<strong>$1<\/strong>")}}))),i.options.typeaheadjs){var l=null,e={},c=i.options.typeaheadjs;n.isArray(c)?(l=c[0],e=c[1]):e=c;i.$input.typeahead(l,e).on("typeahead:selected",n.proxy(function(n,t){e.valueKey?i.add(t[e.valueKey]):i.add(t);i.$input.typeahead("val","")},i))}i.$container.on("click",n.proxy(function(){i.$element.attr("disabled")||i.$input.removeAttr("disabled");i.$input.focus()},i));if(i.options.addOnBlur&&i.options.freeInput)i.$input.on("focusout",n.proxy(function(){n(".typeahead, .twitter-typeahead",i.$container).length===0&&(i.add(i.$input.val()),i.$input.val(""))},i));i.$container.on({focusin:function(){i.$container.addClass(i.options.focusClass)},focusout:function(){i.$container.removeClass(i.options.focusClass)}});i.$container.on("keydown","input",n.proxy(function(t){var r=n(t.target),u=i.findInputWrapper(),f,e,s,h;if(i.$element.attr("disabled")){i.$input.attr("disabled","disabled");return}switch(t.which){case 8:o(r[0])===0&&(f=u.prev(),f.length&&i.remove(f.data("item")));break;case 46:o(r[0])===0&&(e=u.next(),e.length&&i.remove(e.data("item")));break;case 37:s=u.prev();r.val().length===0&&s[0]&&(s.before(u),r.focus());break;case 39:h=u.next();r.val().length===0&&h[0]&&(h.after(u),r.focus())}var c=r.val().length,l=Math.ceil(c/5),a=c+l+1;r.attr("size",Math.max(this.inputSize,r.val().length))},i));i.$container.on("keypress","input",n.proxy(function(t){var r=n(t.target),u,f;if(i.$element.attr("disabled")){i.$input.attr("disabled","disabled");return}u=r.val();f=i.options.maxChars&&u.length>=i.options.maxChars;i.options.freeInput&&(s(t,i.options.confirmKeys)||f)&&(u.length!==0&&(i.add(f?u.substr(0,i.options.maxChars):u),r.val("")),i.options.cancelConfirmKeysOnEmpty===!1&&t.preventDefault());var e=r.val().length,o=Math.ceil(e/5),h=e+o+1;r.attr("size",Math.max(this.inputSize,r.val().length))},i));i.$container.on("click","[data-role=remove]",n.proxy(function(t){i.$element.attr("disabled")||i.remove(n(t.target).closest(".tag").data("item"))},i));i.options.itemValue===r.itemValue&&(i.$element[0].tagName==="INPUT"?i.add(i.$element.val()):n("option",i.$element).each(function(){i.add(n(this).attr("value"),!0)}))},destroy:function(){var n=this;n.$container.off("keypress","input");n.$container.off("click","[role=remove]");n.$container.remove();n.$element.removeData("tagsinput");n.$element.show()},focus:function(){this.$input.focus()},input:function(){return this.$input},findInputWrapper:function(){for(var t=this.$input[0],i=this.$container[0];t&&t.parentNode!==i;)t=t.parentNode;return n(t)}};n.fn.tagsinput=function(t,r,u){var f=[];return this.each(function(){var e=n(this).data("tagsinput"),o;e?t||r?e[t]!==undefined&&(o=e[t].length===3&&u!==undefined?e[t](r,null,u):e[t](r),o!==undefined&&f.push(o)):f.push(e):(e=new i(this,t),n(this).data("tagsinput",e),f.push(e),this.tagName==="SELECT"&&n("option",n(this)).attr("selected","selected"),n(this).val(n(this).val()))}),typeof t=="string"?f.length>1?f:f[0]:f};n.fn.tagsinput.Constructor=i;e=n("<div />");n(function(){n("input[data-role=tagsinput], select[multiple][data-role=tagsinput]").tagsinput()})})(window.jQuery);