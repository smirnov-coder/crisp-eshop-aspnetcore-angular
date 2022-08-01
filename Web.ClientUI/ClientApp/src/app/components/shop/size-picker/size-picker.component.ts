import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { pairwise, startWith, Subject, takeWhile } from "rxjs";

export interface SizeItem {
    size: string;
    available: boolean;
    isSelected: boolean;
}

@Component({
    selector: "size-picker",
    templateUrl: "size-picker.component.html",
    styleUrls: ["size-picker.component.scss"]
})
export class SizePickerComponent implements OnInit {

    private subscribed = true;
    private selectedSub = new Subject<SizeItem>();
    private selected$ = this.selectedSub.asObservable();
    @Input() items: SizeItem[] = [];
    @Input() title: string = "";
    @Input() multiple: boolean = false;
    @Output() itemSelected = new EventEmitter<SizeItem>();
    @Output() itemsSelected = new EventEmitter<SizeItem[]>();

    ngOnInit(): void {
        this.selected$.pipe(
                takeWhile(() => this.subscribed),
                startWith(this.multiple ? null : this.items.find(x => x.isSelected)),
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
                    this.itemsSelected.emit(this.items.filter(x => x.isSelected));
                }
            });
    }

    handleClick(item: SizeItem) {
        this.selectedSub.next(item);
    }
}