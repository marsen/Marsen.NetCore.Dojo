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
        self.log = "setUp "

    def testMethod(self):
        # tracking the method has been called
        self.wasRun = 1
        self.log = self.log + "testMethod "


class TestCaseTest(TestCase):
    def setUp(self):
        self.test = WasRun("testMethod")

    def testTemplateMethod(self):
        self.test.run()
        assert self.test.log == "setUp testMethod "


if __name__ == '__main__':
    TestCaseTest("testTemplateMethod").run()
