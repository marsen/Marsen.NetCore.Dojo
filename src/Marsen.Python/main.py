# This is a sample Python script.

# Press ⌃R to execute it or replace it with your code.
# Press Double ⇧ to search everywhere for classes, files, tool windows, actions, and settings.

# Press the green button in the gutter to run the script.
class WasRun:
    def __init__(self, name):
        self.wasRun = None

    def testmethod(self):
        self.wasRun = 1


if __name__ == '__main__':
    test = WasRun('testMethod')
    print(test.wasRun)
    test.testmethod()
    print(test.wasRun)

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
