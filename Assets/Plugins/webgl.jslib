mergeInto(LibraryManager.library, {

    LoadArea_SetText: function(str) {
        document.getElementById("loadarea").style.display = "block";
        document.getElementById("loadtext").value=Pointer_stringify(str);
		document.getElementById("loadtext").style.display = "inline";
    },
	
	LoadArea_GetText: function() {
        var loadstring = document.getElementById("loadtext").value;
        var bufferSize = lengthBytesUTF8(loadstring) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(loadstring, buffer, bufferSize);
		return buffer;
    },
	
	GameControlReady: function() {
		gameReady = true;
		
		//document.getElementById("#canvas").width = 960;
		//document.getElementById("#canvas").height = 720;
		
		if(typeof GameIsReady == 'function') {
			GameIsReady();
		}
    },
});