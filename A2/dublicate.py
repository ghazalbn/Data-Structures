def IsDublicate(s):
    if(s == ""):
        return True
    n = len(s)
    if(n%2 != 0 or s[0 : int(n/2)] != s[int(n/2) : n]):
        return False
    return IsDublicate(s[1 : int(n/2)])

if __name__ == "__main__":
    s = "hpopohpopo"
    print(IsDublicate(s))