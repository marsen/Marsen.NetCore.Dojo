class TestCase:
    def __init__(self, name):
        # tracking the setUp has been called
        self.wasRun = None
        self.name = name
        self.log = ""

    def setup(
            self):
        pass

    def tear_down(self):
        pass

    def run(self, result):
        result.test_started()
        # todo when setUp raise exception
        self.setup()
        # dynamic run the test case
        try:
            method = getattr(self, self.name)
            method()
        except:
            result.test_failed()

        self.tear_down()
        return result


class WasRun(TestCase):
    def setup(self):
        self.log = "setUp "

    def tear_down(self):
        self.log = self.log + "tearDown "

    def test_method(self):
        # tracking the method has been called
        self.wasRun = 1
        self.log = self.log + "testMethod "

    def test_broken_method(self):
        raise Exception


class TestResult:
    def __init__(self):
        self.errorCounter = 0
        self.runCounter = 0

    def summary(self):
        return "%d run, %d failed" % (self.runCounter, self.errorCounter)

    def test_started(self):
        self.runCounter = self.runCounter + 1

    def test_failed(self):
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
    def setup(self):
        self.result = TestResult()

    def test_template_method(self):
        self.test = WasRun("test_method")
        self.test.run(self.result)
        assert self.test.log == "setUp testMethod tearDown "

    def test_result(self):
        self.test = WasRun("test_method")
        self.test.run(self.result)
        assert ("1 run, 0 failed" == self.result.summary())

    def test_failed_result(self):
        self.test = WasRun("test_broken_method")
        self.test.run(self.result)
        assert ("1 run, 1 failed" == self.result.summary())

    def test_failed_result_formatting(self):
        self.result.test_started()
        self.result.test_failed()
        assert ("1 run, 1 failed" == self.result.summary())

    def test_suite(self):
        suite = TestSuite()
        suite.add(WasRun("test_method"))
        suite.add(WasRun("test_broken_method"))
        suite.run(self.result)
        assert ("2 run, 1 failed" == self.result.summary())


if __name__ == '__main__':
    suite = TestSuite()
    suite.add(TestCaseTest("test_template_method"))
    suite.add(TestCaseTest("test_result"))
    suite.add(TestCaseTest("test_failed_result"))
    suite.add(TestCaseTest("test_failed_result_formatting"))
    suite.add(TestCaseTest("test_suite"))
    result = TestResult()
    suite.run(result)
    print(result.summary())
