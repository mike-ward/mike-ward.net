Determining the local IP address via script
2009-04-20T20:54:33
Why determining the local IP address should be such a monumental task in Windows is anyone’s guess. Here’s some JavaScript code I cobbled together from a couple of different sources for an installer script I’m writing.
    
    function GetIpAddress()
    {
        var ip = "";
        wmi = GetObject("winmgmts:!\\\\.\\root\\cimv2")
        nac = wmi.ExecQuery("Select * from Win32_NetworkAdapterConfiguration Where IPEnabled = True")
    
        for (nac = new Enumerator(nac); !nac.atEnd(); nac.moveNext())
            ip += nac.item().ipAddress(0);
    
        if (ip == "")
            throw "IP address not found";
            
        return ip;
    }

It works but isn't pretty. Surely there must be an easier way? (I’m not running in a browser so no “Remote_Server” header is available).

Signed: Irritated
