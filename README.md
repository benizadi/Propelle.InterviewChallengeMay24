# The approach to the problems

Mainly debugging and understanding the root cause of the problem was a challenge here.
We were dealing with 2 separate problems entangled (DB inconsistency and 3rd Party Fragility)

A very simple Retry logic handled both problems here.

# Assumptions
We are not looking into implementing best practices or patterns here.
We are not looking into refactoring.
We are completely focusing on the main problems stated in the challenge.

# In the real world

- The database issue could be handled in a more mannered way using UnitOfWork
- Repository could get help from EfCore Optimistic Concurrency handling and Duplication detection
- 3rd Party service exceptions could be identified and defined in the retry policy
- I would have used the Service bus native retry policy if available
  - for instance for Azure Service bus https://learn.microsoft.com/en-us/azure/architecture/best-practices/retry-service-specific#service-bus  

# Alternative solution

I lean more towards implementing 3rd party services using Direct API Calls. This way you get responses immediately and it gives you the flexibility of reacting accordingly.

# Notes: (codes were checked completely)
![image](https://github.com/benizadi/Propelle.InterviewChallengeMay24/assets/12119278/31391b0e-dc43-4558-a73a-1d303cfb195e)


# Test Results:
![Screenshot_2](https://github.com/benizadi/Propelle.InterviewChallengeMay24/assets/12119278/61d6f94f-1a47-415c-8ad0-e6854d5225f7)
