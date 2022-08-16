import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: "stepper",
    templateUrl: "stepper.component.html",
    styleUrls: ["stepper.component.scss"]
})
export class StepperComponent {

    @Input() value: number = 1;
    @Output() valueChange = new EventEmitter<any>();

    increase() {
        this.changeValue(this.value + 1);
    }

    decrease() {
        this.changeValue(this.value > 1 ? this.value - 1 : this.value);
    }

    changeValue(value: number) {
        this.value = value;
        this.valueChange.emit(value);
    }

    onInput(event: any) {
        let value = parseInt(event.target.value);
        this.changeValue(isNaN(value) || +value === 0 ? 1 : value);
    }

    onKeyPressed(event: any) {
        return +event.key || (event.keyCode === 48 && this.value > 1) ? true : false;
    }

    onPaste(event: any) {
        var value = event.clipboardData.getData("Text")?.trim();
        return !isNaN(parseInt(value)) ? true : false;
    }
}