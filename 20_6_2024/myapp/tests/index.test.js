const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');
//import {JSDOM} from 'jsdom';

test('simple button click',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'../index.html'),'utf8');
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
        //Raising the event
    dom.window.document.getElementById('btn').click();
    const actual = dom.window.document.getElementById('demo').innerHTML;
    })
