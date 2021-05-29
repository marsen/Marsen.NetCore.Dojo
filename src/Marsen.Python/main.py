# This is a sample Python script.

# Press ⌃R to execute it or replace it with your code.
# Press Double ⇧ to search everywhere for classes, files, tool windows, actions, and settings.

# Press the green button in the gutter to run the script.
class TestCase:
    def __init__(self, name):
        self.name = name

    def setUp(self):
        pass

    def run(self):
        self.setUp()
        # dynamic run the test case
        method = getattr(self, self.name)
        method()


class WasRun(TestCase):

    def setUp(self):
        # tracking the setUp has been called
        self.wasRun = None
        self.wasSetUp = 1

    def testMethod(self):
        # tracking the method has been called
        self.wasRun = 1


class TestCaseTest(TestCase):
    def setUp(self):
        self.test = WasRun("testMethod")

    def testRunning(self):
        self.test.run()
        assert self.test.wasRun

    def testSetUp(self):
        self.test.run()
        assert self.test.wasSetUp


if __name__ == '__main__':
    TestCaseTest("testRunning").run()
    TestCaseTest("testSetUp").run()

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
