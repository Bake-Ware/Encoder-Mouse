import sys
import os
import microcontroller

class PrintSysInfo():
    def __init__(self):
        print('read sys.implementation :-')
        print("sys.implementation.name:\t", sys.implementation.name)
        print("sys.implementation.version:\t", sys.implementation.version)
        print()

        # Check if it's 32/64 bits
        # ref:
        # https://circuitpython.readthedocs.io/en/latest/docs/library/sys.html#sys.maxsize
        bits = 0
        v = sys.maxsize
        while v:
            bits += 1
            v >>= 1
        if bits > 32:
            print("It's 64-bit (or more) platform")
        else:
            print("It's 32-bit (or less) platform")
            
        print('\n======')
        print('os.uname() :-')
        u = os.uname()
        print("type: ", type(u))
        print(dir(u))
        print(u)

        print("sysname:\t", u.sysname)
        print("nodename:\t", u.nodename)
        print("release:\t", u.release)
        print("version:\t", u.version)
        print("machine:\t", u.machine)
            
        print('\n======')

        print()
        print('microcontroller.cpus :-')
        numOfCpu = len(microcontroller.cpus)
        print('Number of CPU: ', numOfCpu)
        for i in range(numOfCpu):
            print('CPU[', i, ']:')
            print('\tfrequency:\t', microcontroller.cpus[i].frequency)
            print('\ttemperature:\t', microcontroller.cpus[i].temperature)
            print('\tvoltage:\t', microcontroller.cpus[i].voltage)

        print('\n======')
