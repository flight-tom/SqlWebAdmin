document.onclick=clickHandler;

function clickHandler(evt)
{
	switch(event.srcElement.type) {
		case 'submit':
		if (typeof(Page_IsValid) != "undefined" && Page_IsValid) {
			event.srcElement.style.cursor = 'wait';
			document.body.style.cursor = 'wait';
		}
		break;
	}
}
