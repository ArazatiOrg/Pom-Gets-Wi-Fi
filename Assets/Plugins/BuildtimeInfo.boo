import UnityEngine
 
macro build_buildtime_info():
	dateString = System.DateTime.Now.ToString()
	yield [|
		class BuildtimeInfo:
			static def DateTimeString() as string:
				return "${$(dateString)}"
	|]
 
build_buildtime_info
 
# # Now you can do this:
# Debug.Log( BuildtimeInfo.DateTimeString() )
