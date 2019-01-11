#
# Tello Python3 Demo 
#

import socket, time

host = ''
port = 9000
locaddr = (host,port)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
tello_address = ('192.168.10.1', 8889)
sock.bind(locaddr)

sock.sendto(‘command’.encode(encoding="utf-8"), tello_address)
time.sleep(5)

# Takeoff
sock.sendto(‘takeoff’.encode(encoding="utf-8"), tello_address)
time.sleep(5)


# Rotate clockwise 360
sock.sendto(‘tcw 360’.encode(encoding="utf-8"), tello_address)
time.sleep(5)

# Land
sock.sendto(‘land’.encode(encoding="utf-8"), tello_address)
time.sleep(5)
