class TestCase:
    def __init__(self, name):
        self.name = name

    def setUp(self):
        pass

    def tearDown(self):
        pass

    def run(self, result):
        result.testStarted()
        # todo when setUp raise exception
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


class TestSuite:
    def __init__(self):
        self.tests = []

    def add(self, test):
        self.tests.append(test)

    def run(self, result):
        for test in self.tests:
            test.run(result)
        # print(">>>" + result.summary())
        return result


class TestCaseTest(TestCase):
    def setUp(self):
        self.result = TestResult()

    def testTemplateMethod(self):
        self.test = WasRun("testMethod")
        self.test.run(self.result)
        assert self.test.log == "setUp testMethod tearDown "

    def testResult(self):
        self.test = WasRun("testMethod")
        self.test.run(self.result)
        assert ("1 run, 0 failed" == self.result.summary())

    def testFailedResult(self):
        self.test = WasRun("testBrokenMethod")
        self.test.run(self.result)
        assert ("1 run, 1 failed" == self.result.summary())

    def testFailedResultFormatting(self):
        self.result.testStarted()
        self.result.testFailed()
        assert ("1 run, 1 failed" == self.result.summary())

    def testSuite(self):
        suite = TestSuite()
        suite.add(WasRun("testMethod"))
        suite.add(WasRun("testBrokenMethod"))
        suite.run(self.result)
        assert ("2 run, 1 failed" == self.result.summary())


if __name__ == '__main__':
    suite = TestSuite()
    suite.add(TestCaseTest("testTemplateMethod"))
    suite.add(TestCaseTest("testResult"))
    suite.add(TestCaseTest("testFailedResult"))
    suite.add(TestCaseTest("testFailedResultFormatting"))
    suite.add(TestCaseTest("testSuite"))
    result = TestResult()
    suite.run(result)
    print(result.summary())
