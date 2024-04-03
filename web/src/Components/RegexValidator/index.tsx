import { Component, useState } from "react";
import { useRegexValidator } from "../useRegexValidator";
import { regexValidatorResult } from "../../types";


export function RegexValidator() {
  const validator = useRegexValidator;
  const [regEx, setregEx] = useState(''); // Declare a state variable...
  const [list, setList] = useState<regexValidatorResult[]>([]);

  function validate(): void {
   const x = validator(regEx);

   setList(x);
  }

  return (
    <>
    <div className="flex bg-white rounded mb-4">
 
  <input className="shadow appearance-none w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"  placeholder="/.*@[a-z0-9.-]*/i" onChange={e => setregEx(e.target.value)} />
 
 
    <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline ml-2" type="button" onClick={() => validate()}>validate</button> 
    
    </div>
 
    {list.filter(x=>x.validType).length > 0 && (
    <div>
      <div className="bg-white mb-2  px-2 py-2"> 
      <div className=" mb-2 ">
        <div className="mb-2">Here are some <strong>valid</strong> email addresses that dont pass</div>
     <ul className="overflow-x-scroll pt-2 rounded"> 
        {list.map(result => (
         result.validType && (<li key={result.test}>❌&nbsp;{result.test}</li>)
        ))}
      </ul></div>
       
    </div></div>
    )}

{list.filter(x=>!x.validType).length > 0 && (
    <div className="mt-4">
      
      <div className="bg-white mb-2 px-2 py-2">
      <div className="mb-2"> 
      <div className="mb-2">        Here are some <strong>invalid</strong> email addresses that dont pass</div>
    <ul className="overflow-x-scroll pt-2 rounded	"> 
        {list.map(result => (
         !result.validType && (<li className="text-ellipsis	 ml-4 pr-5" key={result.test}>❌&nbsp;{result.test}</li>)
        ))}
      </ul></div>
    </div></div>
    )}

    
</>
  );
}
 