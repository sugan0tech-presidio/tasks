class TestClass:
    something = "test" # also behaves as class variable ( static )
    # works as a constructor, initializer for a class
    def __init__(self, vlue = "undefined", data = "undefined") -> None:
        self.vlue = vlue
        self.data = data
        print("The object has been initialized") 

    def __str__(self) -> str:
        return f"value\t:{self.vlue} \ndata\t:{self.data}"

    if something == "test":
        input("Enter the value")
        print("conditions inside class")



tst = TestClass("price", "it's the amount for someting to be sold")
print(tst)


def scope_test():
    def do_local():
        # value only be on current function scope
        spam = "local spam"

    def do_nonlocal():
        # value should be set with this current code block ig
        # like if we want to modify paren't function in child
        nonlocal spam
        spam = "nonlocal spam"

    def do_global():
        # this thign is global beyond this code block
        # access throughout this program and readonly, if we try to override it becomes local
        global spam
        spam = "global spam"

    spam = "test spam"

    do_local()
    print("After local assignment:", spam)
    do_nonlocal()
    print("After nonlocal assignment:", spam)
    do_global()
    print("After global assignment:", spam)

scope_test()
print("In global scope:", spam)


# Inheritance
class Mapping:
    def __init__(self, iterable):
        self.items_list = []
        self.__update(iterable)

    def update(self, iterable):
        for item in iterable:
            self.items_list.append(item)

    __update = update   # private copy of original update() method

class MappingSubclass(Mapping):

    def update(self, keys, values):
        # provides new signature for update()
        # but does not break __init__()
        for item in zip(keys, values):
            self.items_list.append(item)


