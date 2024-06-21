const {JSDOM} = require('jsdom');

test('simple button click',()=>{
    const dom = new JSDOM(`
        <!DOCTYPE html>
        <html>
            <body>
                <button id="btn">Click me</button>
                <p id="demo"></p>
                <script>
                    document.getElementById('btn').addEventListener('click',()=>{
                        document.getElementById('demo').innerHTML = 'Hello World';
                    });
                </script>
            </body>
        </html>`,{runScripts: 'dangerously',resources: 'usable'});

    dom.window.document.getElementById('btn').click();
    const actual = dom.window.document.getElementById('demo').innerHTML;
    expect(actual).toBe('Hello World');
})
