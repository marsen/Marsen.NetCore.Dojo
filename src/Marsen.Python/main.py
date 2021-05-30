class TestCase:
    def __init__(self, name):
        self.name = name

    def setUp(self):
        pass

    def tearDown(self):
        pass

    def run(self):
        result = TestResult()
        result.testStarted()
        self.setUp()
        # dynamic run the test case
        try:
            method = getattr(self, self.name)
            method()
        except:
            result.testFailed()

        self.tearDown()
        return result


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

    def testBrokenMethod(self):
        raise Exception


class TestResult:
    def __init__(self):
        self.errorCounter = 0
        self.runCounter = 0

    def summary(self):
        return "%d run, %d failed" % (self.runCounter, self.errorCounter)

    def testStarted(self):
        self.runCounter = self.runCounter + 1

    def testFailed(self):
        self.errorCounter = self.errorCounter + 1


class TestCaseTest(TestCase):
    def testTemplateMethod(self):
        self.test = WasRun("testMethod")
        self.test.run()
        assert self.test.log == "setUp testMethod tearDown "

    def testResult(self):
        self.test = WasRun("testMethod")
        result = self.test.run()
        assert ("1 run, 0 failed" == result.summary())

    def testFailedResult(self):
        self.test = WasRun("testBrokenMethod")
        result = self.test.run()
        assert ("1 run, 1 failed" == result.summary())

    def testFailedResultFormatting(self):
        result = TestResult()
        result.testStarted()
        result.testFailed()
        assert ("1 run, 1 failed" == result.summary())


if __name__ == '__main__':
    TestCaseTest("testTemplateMethod").run()
    TestCaseTest("testResult").run()
    TestCaseTest("testFailedResult").run()
    TestCaseTest("testFailedResultFormatting").run()
