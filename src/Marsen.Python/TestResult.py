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