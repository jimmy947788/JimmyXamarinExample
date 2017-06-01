package com.daedalus.mylibrary;

/**
 * Created by JimmyWu on 2017/6/1.
 */

public class Utilities {
    public static String Echo(String message)
    {
        if(message.length() == 0) {
            return String.format("Dude %s, you didnt give me a message!", "bro");
        }
        return message;
    }

    public String Hello(String name)
    {
        if(name.length() == 0) {
            return String.format("Dude %s, you didnt give me a name!", "bro");
        }
        return String.format("*Waves* Hello %s! Welcome to the Xamarin binding sample!", name);
    }

    public int Add(int operandUn, int operandDeux)
    {
        return operandUn + operandDeux;
    }

    public int Multiply(int operandUn, int operandDeux)
    {
        return operandUn * operandDeux;
    }

    IUtilityCallback _callback;
    // This is an example of how to set a block function for later use.
    public void SetCallback(IUtilityCallback callback)
    {
        _callback = callback;
    }

    // This is an example of how to invoke a block function.
    public void InvokeCallback(String message)
    {
        _callback.callbackCall (message);
    }
}
