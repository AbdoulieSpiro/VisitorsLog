/** Boot strapper */
AttachEventToElement(window, 'load', WordVisualizer_Load);

/**
  * Attach event to element
  *
  * @param  DOMElement element
  * @param  string     eventName
  * @param  delegate   eventHandler
  */
function AttachEventToElement(element, eventName, eventHandler) {
    if (element.attachEvent) {
        element.attachEvent('on' + eventName, eventHandler);
    } else {
        element.addEventListener(eventName, eventHandler, false);
    }
}

/**
  * WordVisualizer_Load
  */
function WordVisualizer_Load() {
    AttachEventToElement(document.getElementById('Title'), 'mouseover', WordVisualizer_CoreProperties_Title_MouseOver);
    AttachEventToElement(document.getElementById('Title'), 'mouseout', WordVisualizer_CoreProperties_Title_MouseOut);
    AttachEventToElement(document.getElementById('Title'), 'click', WordVisualizer_CoreProperties_Title_Click);
    
    document.getElementById('Details').className = 'invisible';
}

/**
  * WordVisualizer_CoreProperties_Title_MouseOver
  */
function WordVisualizer_CoreProperties_Title_MouseOver() {
    document.getElementById('Title').className = 'hover';
}

/**
  * WordVisualizer_CoreProperties_Title_MouseOut
  */
function WordVisualizer_CoreProperties_Title_MouseOut() {
    document.getElementById('Title').className = '';
}

/**
  * WordVisualizer_CoreProperties_Title_Click
  */
function WordVisualizer_CoreProperties_Title_Click() {
    if (document.getElementById('Details').className == 'visible') {
        document.getElementById('Details').className = 'invisible';
    } else {
        document.getElementById('Details').className = 'visible';
    }
}