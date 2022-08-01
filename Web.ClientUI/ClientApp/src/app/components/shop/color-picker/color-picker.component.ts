import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from "@angular/core";
import { pairwise } from "rxjs/internal/operators/pairwise";
import { startWith } from "rxjs/internal/operators/startWith";
import { takeWhile } from "rxjs/internal/operators/takeWhile";
import { Subject } from "rxjs/internal/Subject";

export interface ColorItem {
    id: number;
    name: string;
    hex: string;
    isSelected: boolean;
}

@Component({
    selector: "color-picker",
    templateUrl: "color-picker.component.html",
    styleUrls: ["color-picker.component.scss"]
})
export class ColorPickerComponent implements OnInit, OnDestroy {

    private subscribed = true;
    private selectedSub = new Subject<ColorItem>();
    private selected$ = this.selectedSub.asObservable();
    @Input() items?: ColorItem[];
    @Input() title?: string;
    @Input() multiple: boolean = false;
    @Output() itemSelected = new EventEmitter<ColorItem>();
    @Output() itemsSelected = new EventEmitter<ColorItem[]>();

    ngOnInit(): void {
        this.selected$.pipe(
            takeWhile(() => this.subscribed),
            startWith(this.multiple ? null : this.items?.find(x => x.isSelected)),
            pairwise()
        ).subscribe(([prev, current]) => {
            if (!this.multiple) {
                if (!prev) {
                    current!.isSelected = true;
                } else if (!current?.isSelected) {
                    current!.isSelected = true;
                    prev.isSelected = false;
                }
                if (current?.isSelected) {
                    this.itemSelected.emit(current!);
                }
            } else {
                current!.isSelected = !current?.isSelected;
                this.itemsSelected.emit(this.items?.filter(x => x.isSelected));
            }
        });
    }

    ngOnDestroy(): void {
        this.subscribed = false;
    }

    handleClick(item: ColorItem) {
        this.selectedSub.next(item);
    }
}