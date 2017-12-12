# Fallacious Game

## General information

Environment: THE pub

Variable: Bob, a mid-aged, single?, bald?, white? man


## Outline

```python
def main(Bob, random_events, maximum_event):
    event_count = 0
    results = []
    enter_the_pub(Bob)

    for event_count <= maximum_event:
        random_num = random_gen(len(random_events))
        result = random_events[random_num].happen()
        if (not result):
            break
        results.append(result)
        random_events.remove(random_num)
        event_count += 1
        
    return(leave_the_pub(results))
```
