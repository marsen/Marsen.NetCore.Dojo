class TestCase:
    def __init__(self, name):
        self.name = name

    def setUp(self):
        pass

    def tearDown(self):
        pass

    def run(self):
        self.setUp()
        # dynamic run the test case
        method = getattr(self, self.name)
        method()
        self.tearDown()
        return TestResult()


class WasRun(TestCase):
    def setUp(self):
        # tracking the setUp has been called
        self.wasRun = None
        self.log = "setUp "

    def tearDown(self):
        self.log = self.log + "tearDown "

    def testMethod(self):
        # tracking the method has been called
        self.wasRun = 1
        self.log = self.log + "testMethod "

class TestResult:
    def summary(self):
        return "1 run, 0 failed"

class TestCaseTest(TestCase):
    def testTemplateMethod(self):
        self.test = WasRun("testMethod")
        self.test.run()
        assert self.test.log == "setUp testMethod tearDown "

    def testResult(self):
        self.test = WasRun("testMethod")
        result = self.test.run()
        assert ("1 run, 0 failed" == result.summary())


if __name__ == '__main__':
    TestCaseTest("testTemplateMethod").run()
    TestCaseTest("testResult").run()
