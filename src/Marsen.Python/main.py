# This is a sample Python script.

# Press ⌃R to execute it or replace it with your code.
# Press Double ⇧ to search everywhere for classes, files, tool windows, actions, and settings.

# Press the green button in the gutter to run the script.
class TestCase:
    def __init__(self, name):
        self.name = name

    def run(self):
        method = getattr(self, self.name)
        method()


class WasRun(TestCase):
    def __init__(self, name):
        self.wasRun = None
        TestCase.__init__(self, name)

    def testmethod(self):
        self.wasRun = 1


class TestCaseTest(TestCase):
    def testRunning(self):
        test = WasRun("testmethod")
        print(test.wasRun)
        test.run()
        print(test.wasRun)


if __name__ == '__main__':
    TestCaseTest("testRunning").run()

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
